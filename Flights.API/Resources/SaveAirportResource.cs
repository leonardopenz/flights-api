using System;
using System.ComponentModel.DataAnnotations;

namespace Flights.API.Resources
{
    public class SaveAirportResource
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }
    }
}