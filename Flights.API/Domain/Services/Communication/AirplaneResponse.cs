
using Flights.API.Domain.Models;

namespace Flights.API.Domain.Services.Communication
{
    public class AirplaneResponse : BaseResponse<Airplane>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="airplane">Saved airplane.</param>
        /// <returns>Response.</returns>
        public AirplaneResponse(Airplane airplane) : base(airplane)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public AirplaneResponse(string message) : base(message)
        { }
    }
}