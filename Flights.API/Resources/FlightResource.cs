using System;
using System.Collections.Generic;

namespace Flights.API.Resources
{
    public class FlightResource
    {
        public int FlightId { get; set; }
        public string Number { get; set; }
        public AirportResource AirportOrigin { get; set; }
        public AirportResource AirportDestination { get; set; }
        public AirplaneResource Airplane { get; set; }
        public DateTime DateDeparture { get; set; }
        public DateTime DateArrival { get; set; }
        public IList<FlightPassengerResource> FlightPassengers { get; set; } = new List<FlightPassengerResource>();
    }
}