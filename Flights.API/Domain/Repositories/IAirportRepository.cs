using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;

namespace Flights.API.Domain.Repositories
{
    public interface IAirportRepository
    {
        Task<IEnumerable<Airport>> ListAsync();
        Task AddAsync(Airport airport);
        Task<Airport> FindByIdAsync(int id);
        void Update(Airport airport);
        void Remove(Airport airport);
    }
}