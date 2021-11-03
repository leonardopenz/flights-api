
using Flights.API.Domain.Models;

namespace Flights.API.Domain.Services.Communication
{
    public class PassengerResponse : BaseResponse<Passenger>
    {
        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="passenger">Saved passenger.</param>
        /// <returns>Response.</returns>
        public PassengerResponse(Passenger passenger) : base(passenger)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public PassengerResponse(string message) : base(message)
        { }
    }
}