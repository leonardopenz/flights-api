using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Models.Queries;

namespace Flights.API.Domain.Repositories
{
    public interface IFlightRepository
    {
        Task<QueryResult<Flight>> ListAsync(FlightsQuery query);
        Task AddAsync(Flight flight);
        Task<Flight> FindByIdAsync(int id);
        void Update(Flight flight);
        void Remove(Flight flight);
    }
}