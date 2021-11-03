using System;
using System.Collections.Generic;

namespace Flights.API.Resources
{
    public class PassengerResource
    {
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // public IList<FlightPassengerResource> FlightPassenger { get; set; } = new List<FlightPassengerResource>();
    }
}