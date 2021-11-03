namespace Flights.API.Domain.Models.Queries
{
    public class FlightsQuery : Query
    {
        public int? AirportId { get; set; }

        public FlightsQuery(int? airportId, int page, int itemsPerPage) : base(page, itemsPerPage)
        {
            AirportId = airportId;
        }
    }
}