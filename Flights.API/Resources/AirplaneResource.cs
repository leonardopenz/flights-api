using System;

namespace Flights.API.Resources
{
    public class AirplaneResource
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Registration { get; set; }
        public string Country { get; set; }
    }
}