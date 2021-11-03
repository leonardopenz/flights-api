using System.ComponentModel;

namespace Flights.API.Domain.Models
{
    public class FlightPassenger
    {
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public string PassportNumber { get; set; }
        public Passenger Passenger { get; set; }
        
        public string TicketNumber { get; set; }
        public ServiceClass ServiceClass { get; set; }
    }

    public enum ServiceClass : byte
    {
        [Description("EC")]
        Economy = 1,

        [Description("PE")]
        PremiumEconomy = 2,

        [Description("BP")]
        BusinessPremier = 3
    }
}
