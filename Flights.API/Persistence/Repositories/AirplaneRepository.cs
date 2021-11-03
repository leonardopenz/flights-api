using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Flights.API.Domain.Models;
using Flights.API.Domain.Repositories;

namespace Flights.API.Persistence.Repositories
{
    public class AirplaneRepository : BaseRepository, IAirplaneRepository
    {
        public AirplaneRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Airplane>> ListAsync()
        {
            return await _context.Airplanes
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        public async Task AddAsync(Airplane airplane)
        {
            await _context.Airplanes.AddAsync(airplane);
        }

        public async Task<Airplane> FindByIdAsync(int id)
        {
            return await _context.Airplanes.FindAsync(id);
        }

        public void Update(Airplane airplane)
        {
            _context.Airplanes.Update(airplane);
        }

        public void Remove(Airplane airplane)
        {
            _context.Airplanes.Remove(airplane);
        }
    }
}