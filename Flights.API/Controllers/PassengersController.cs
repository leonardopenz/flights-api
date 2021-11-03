using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Flights.API.Domain.Models;
using Flights.API.Domain.Services;
using Flights.API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Flights.API.Controllers
{
    [ApiController]
    [Route("/api/passengers")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PassengersController : Controller
    {
        private readonly IPassengerService _passengerService;
        private readonly IMapper _mapper;

        public PassengersController(IPassengerService passengerService, IMapper mapper)
        {
            _passengerService = passengerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all passengers.
        /// </summary>
        /// <returns>List of passengers.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PassengerResource>), 200)]
        public async Task<IEnumerable<PassengerResource>> ListAsync()
        {
            var passengers = await _passengerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Passenger>, IEnumerable<PassengerResource>>(passengers);

            return resources;
        }

        /// <summary>
        /// Saves a new passenger.
        /// </summary>
        /// <param name="resource">Passengers data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PassengerResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SavePassengerResource resource)
        {
            var passengers = _mapper.Map<SavePassengerResource, Passenger>(resource);
            var result = await _passengerService.SaveAsync(passengers);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var passengersResource = _mapper.Map<Passenger, PassengerResource>(result.Resource);
            return Ok(passengersResource);
        }

        /// <summary>
        /// Updates an existing passenger according to an identifier.
        /// </summary>
        /// <param name="passport">Passenger identifier.</param>
        /// <param name="resource">Updated passenger data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{passport}")]
        [ProducesResponseType(typeof(PassengerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(string passport, [FromBody] SavePassengerResource resource)
        {
            var passengers = _mapper.Map<SavePassengerResource, Passenger>(resource);
            var result = await _passengerService.UpdateAsync(passport, passengers);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var passengersResource = _mapper.Map<Passenger, PassengerResource>(result.Resource);
            return Ok(passengersResource);
        }

        /// <summary>
        /// Deletes a given passengers according to an identifier.
        /// </summary>
        /// <param name="passport">Passengers identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{passport}")]
        [ProducesResponseType(typeof(PassengerResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(string passport)
        {
            var result = await _passengerService.DeleteAsync(passport);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var passengersResource = _mapper.Map<Passenger, PassengerResource>(result.Resource);
            return Ok(passengersResource);
        }
    }
}
