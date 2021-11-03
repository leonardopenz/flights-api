using System;

namespace Flights.API.Resources
{
    public class FlightsQueryResource : QueryResource
    {
        public int? AirportId { get; set; }
    }
}