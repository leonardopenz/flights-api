using System.ComponentModel.DataAnnotations;

namespace Flights.API.Domain.Models
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
