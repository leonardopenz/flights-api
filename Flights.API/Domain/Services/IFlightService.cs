using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Models.Queries;
using Flights.API.Domain.Services.Communication;

namespace Flights.API.Domain.Services
{
    public interface IFlightService
    {
        Task<QueryResult<Flight>> ListAsync(FlightsQuery query);
        Task<FlightResponse> SaveAsync(Flight flight);
        Task<FlightResponse> UpdateAsync(int id, Flight flight);
        Task<FlightResponse> DeleteAsync(int id);
    }
}