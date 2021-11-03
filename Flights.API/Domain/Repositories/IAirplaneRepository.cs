using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;

namespace Flights.API.Domain.Repositories
{
    public interface IAirplaneRepository
    {
        Task<IEnumerable<Airplane>> ListAsync();
        Task AddAsync(Airplane airplane);
        Task<Airplane> FindByIdAsync(int id);
        void Update(Airplane airplane);
        void Remove(Airplane airplane);
    }
}