
using Flights.API.Domain.Models;

namespace Flights.API.Domain.Services.Communication
{
    public class FlightResponse : BaseResponse<Flight>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="flight">Saved flight.</param>
        /// <returns>Response.</returns>
        public FlightResponse(Flight flight) : base(flight)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public FlightResponse(string message) : base(message)
        { }
    }
}