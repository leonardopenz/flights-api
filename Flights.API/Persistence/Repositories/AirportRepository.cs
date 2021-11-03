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
    public class AirportRepository : BaseRepository, IAirportRepository
    {
        public AirportRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Airport>> ListAsync()
        {
            return await _context.Airports
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task AddAsync(Airport airport)
        {
            await _context.Airports.AddAsync(airport);
        }

        public async Task<Airport> FindByIdAsync(int id)
        {
            return await _context.Airports.FindAsync(id);
        }

        public void Update(Airport airport)
        {
            _context.Airports.Update(airport);
        }

        public void Remove(Airport airport)
        {
            _context.Airports.Remove(airport);
        }
    }
}