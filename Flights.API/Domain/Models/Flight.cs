using System;
using System.Collections.Generic;

namespace Flights.API.Domain.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Number { get; set; }

        public int AirportOriginId { get; set; }
        public Airport AirportOrigin { get; set; }

        public int AirportDestinationId { get; set; }
        public Airport AirportDestination { get; set; }

        public int AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public DateTime DateDeparture { get; set; }
        public DateTime DateArrival { get; set; }

        public IList<FlightPassenger> FlightPassengers { get; set; }
    }
}
