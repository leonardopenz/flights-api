using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flights.API.Resources
{
    public class SaveFlightResource
    {
        [Required]
        [MaxLength(50)]
        public string Number { get; set; }

        [Required]
        public int AirportOriginId { get; set; }

        [Required]
        public int AirportDestinationId { get; set; }

        [Required]
        public int AirplaneId { get; set; }

        [Required]
        public DateTime DateDeparture { get; set; }

        [Required]
        public DateTime DateArrival { get; set; }

        public IList<FlightPassengerResource> FlightPassengers { get; set; }
    }
}