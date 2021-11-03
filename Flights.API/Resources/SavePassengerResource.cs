using System.ComponentModel.DataAnnotations;

namespace Flights.API.Resources
{
    public class SavePassengerResource
    {
        [Required]
        public int PassportNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
    }
}