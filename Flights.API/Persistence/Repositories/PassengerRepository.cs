using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Flights.API.Domain.Models;
using Flights.API.Domain.Repositories;
using Flights.API.Persistence;
using System.Linq;
using Flights.API.Domain.Models.Queries;

namespace Flights.API.Persistence.Repositories
{
    public class PassengerRepository : BaseRepository, IPassengerRepository
    {
        public PassengerRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Passenger>> ListAsync()
        {
            return await _context.Passengers
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task AddAsync(Passenger passenger)
        {
            await _context.Passengers.AddAsync(passenger);
        }

        public async Task<Passenger> FindByIdAsync(string passport)
        {
            return await _context.Passengers.FirstOrDefaultAsync(p => p.PassportNumber == passport);
        }

        public void Update(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
        }

        public void Remove(Passenger passenger)
        {
            _context.Passengers.Remove(passenger);
        }
    }
}