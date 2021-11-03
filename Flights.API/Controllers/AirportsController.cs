using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flights.API.Domain.Models;
using Flights.API.Domain.Services;
using Flights.API.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Flights.API.Controllers
{
    [ApiController]
    [Route("/api/airports")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;
        private readonly IMapper _mapper;

        public AirportsController(IAirportService airportService, IMapper mapper)
        {
            _airportService = airportService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all airports.
        /// </summary>
        /// <returns>List of airports.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AirportResource>), 200)]
        public async Task<IEnumerable<AirportResource>> ListAsync()
        {
            var airports = await _airportService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Airport>, IEnumerable<AirportResource>>(airports);

            return resources;
        }

        /// <summary>
        /// Saves a new airport.
        /// </summary>
        /// <param name="resource">Airport data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(AirportResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveAirportResource resource)
        {
            var airport = _mapper.Map<SaveAirportResource, Airport>(resource);
            var result = await _airportService.SaveAsync(airport);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var airportResource = _mapper.Map<Airport, AirportResource>(result.Resource);
            return Ok(airportResource);
        }

        /// <summary>
        /// Updates an existing airport according to an identifier.
        /// </summary>
        /// <param name="id">Airport identifier.</param>
        /// <param name="resource">Updated airport data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AirportResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAirportResource resource)
        {
            var airport = _mapper.Map<SaveAirportResource, Airport>(resource);
            var result = await _airportService.UpdateAsync(id, airport);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var airportResource = _mapper.Map<Airport, AirportResource>(result.Resource);
            return Ok(airportResource);
        }

        /// <summary>
        /// Deletes a given airport according to an identifier.
        /// </summary>
        /// <param name="id">Airport identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AirportResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _airportService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var airportResource = _mapper.Map<Airport, AirportResource>(result.Resource);
            return Ok(airportResource);
        }
    }
}
