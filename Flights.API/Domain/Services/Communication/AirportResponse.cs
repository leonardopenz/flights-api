
using Flights.API.Domain.Models;

namespace Flights.API.Domain.Services.Communication
{
    public class AirportResponse : BaseResponse<Airport>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="airport">Saved airport.</param>
        /// <returns>Response.</returns>
        public AirportResponse(Airport airport) : base(airport)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AirportResponse(string message) : base(message)
        { }
    }
}