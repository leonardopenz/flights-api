using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flights.API.Domain.Models;
using Flights.API.Domain.Services;
using Flights.API.Resources;
using Flights.API.Domain.Models.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Flights.API.Controllers
{
    [ApiController]
    [Route("/api/flights")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public FlightsController(IFlightService flightService, IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all flights.
        /// </summary>
        /// <returns>List of flights.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<FlightResource>), 200)]
        public async Task<QueryResultResource<FlightResource>> ListAsync([FromQuery] FlightsQueryResource query)
        {
            var flightsQuery = _mapper.Map<FlightsQueryResource, FlightsQuery>(query);
            var queryResult = await _flightService.ListAsync(flightsQuery);

            var resource = _mapper.Map<QueryResult<Flight>, QueryResultResource<FlightResource>>(queryResult);

            return resource;
        }

        /// <summary>
        /// Saves a new flight.
        /// </summary>
        /// <param name="resource">Flight data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(FlightResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveFlightResource resource)
        {
            var flight = _mapper.Map<SaveFlightResource, Flight>(resource);
            var result = await _flightService.SaveAsync(flight);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var flightResource = _mapper.Map<Flight, FlightResource>(result.Resource);
            return Ok(flightResource);
        }

        /// <summary>
        /// Updates an existing flight according to an identifier.
        /// </summary>
        /// <param name="id">Flight identifier.</param>
        /// <param name="resource">Updated flight data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FlightResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveFlightResource resource)
        {
            var flight = _mapper.Map<SaveFlightResource, Flight>(resource);
            var result = await _flightService.UpdateAsync(id, flight);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var flightResource = _mapper.Map<Flight, FlightResource>(result.Resource);
            return Ok(flightResource);
        }

        /// <summary>
        /// Deletes a given flight according to an identifier.
        /// </summary>
        /// <param name="id">Flight identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FlightResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _flightService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var flightResource = _mapper.Map<Flight, FlightResource>(result.Resource);
            return Ok(flightResource);
        }
    }
}
