using System.ComponentModel.DataAnnotations;

namespace Flights.API.Domain.Models
{
    public class UserRegistration
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
