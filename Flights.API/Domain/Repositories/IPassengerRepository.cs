using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;

namespace Flights.API.Domain.Repositories
{
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> ListAsync();
        Task AddAsync(Passenger passenger);
        Task<Passenger> FindByIdAsync(string passport);
        void Update(Passenger passenger);
        void Remove(Passenger passenger);
    }
}