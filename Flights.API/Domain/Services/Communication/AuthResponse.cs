
using System.Collections.Generic;

namespace Flights.API.Domain.Services.Communication
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }
}