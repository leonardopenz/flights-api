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
    [Route("/api/airplanes")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AirplanesController : Controller
    {
        private readonly IAirplaneService _airplaneService;
        private readonly IMapper _mapper;

        public AirplanesController(IAirplaneService airplaneService, IMapper mapper)
        {
            _airplaneService = airplaneService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all airplanes.
        /// </summary>
        /// <returns>List of airplanes.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AirplaneResource>), 200)]
        public async Task<IEnumerable<AirplaneResource>> ListAsync()
        {
            var airplanes = await _airplaneService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Airplane>, IEnumerable<AirplaneResource>>(airplanes);

            return resources;
        }

        /// <summary>
        /// Saves a new airplane.
        /// </summary>
        /// <param name="resource">Airplanes data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AirplaneResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveAirplaneResource resource)
        {
            var airplanes = _mapper.Map<SaveAirplaneResource, Airplane>(resource);
            var result = await _airplaneService.SaveAsync(airplanes);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var airplanesResource = _mapper.Map<Airplane, AirplaneResource>(result.Resource);
            return Ok(airplanesResource);
        }

        /// <summary>
        /// Updates an existing airplane according to an identifier.
        /// </summary>
        /// <param name="id">Airplane identifier.</param>
        /// <param name="resource">Updated airplane data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AirplaneResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAirplaneResource resource)
        {
            var airplanes = _mapper.Map<SaveAirplaneResource, Airplane>(resource);
            var result = await _airplaneService.UpdateAsync(id, airplanes);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var airplanesResource = _mapper.Map<Airplane, AirplaneResource>(result.Resource);
            return Ok(airplanesResource);
        }

        /// <summary>
        /// Deletes a given airplanes according to an identifier.
        /// </summary>
        /// <param name="id">Airplanes identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AirplaneResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _airplaneService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var airplanesResource = _mapper.Map<Airplane, AirplaneResource>(result.Resource);
            return Ok(airplanesResource);
        }
    }
}
