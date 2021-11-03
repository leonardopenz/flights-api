using System.Collections.Generic;

namespace Flights.API.Domain.Models
{
    public class Passenger
    {
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<FlightPassenger> FlightPassengers { get; set; }
    }
}
