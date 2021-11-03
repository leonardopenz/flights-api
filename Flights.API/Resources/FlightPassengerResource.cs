using System;

namespace Flights.API.Resources
{
    public class FlightPassengerResource
    {
        public string PassportNumber { get; set; }
        public PassengerResource Passenger { get; set; }
        public string TicketNumber { get; set; }
        public Domain.Models.ServiceClass ServiceClass { get; set; }
    }
}