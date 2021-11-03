using System;
using System.ComponentModel.DataAnnotations;

namespace Flights.API.Resources
{
    public class SaveAirplaneResource
    {
        public string Type { get; set; }
        
        [Required]
        public string Registration { get; set; }

        public string Country { get; set; }
    }
}