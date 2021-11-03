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
    public class FlightRepository : BaseRepository, IFlightRepository
    {
        public FlightRepository(AppDbContext context) : base(context) { }

        public async Task<QueryResult<Flight>> ListAsync(FlightsQuery query)
        {
            IQueryable<Flight> queryable = _context.Flights
                                                    .Include(p => p.Airplane)
                                                    .Include(p => p.AirportOrigin)
                                                    .Include(p => p.AirportDestination)
                                                    .Include(p => p.FlightPassengers)
													.ThenInclude(p => p.Passenger);

            if (query.AirportId.HasValue && query.AirportId > 0)
				queryable = queryable.Where(p => p.AirportOriginId == query.AirportId || p.AirportDestinationId == query.AirportId);

			int totalItems = await queryable.CountAsync();

            List<Flight> flights = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
													.Take(query.ItemsPerPage)
													.ToListAsync();

            return new QueryResult<Flight>
			{
				Items = flights,
				TotalItems = totalItems,
			};
        }

        public async Task<Flight> FindByIdAsync(int id)
		{
			return await _context.Flights
								 .Include(p => p.Airplane)
									.Include(p => p.AirportOrigin)
									.Include(p => p.AirportDestination)
									.Include(p => p.FlightPassengers)
									.ThenInclude(p => p.Passenger)
								 .FirstOrDefaultAsync(p => p.FlightId == id);
		}

		public async Task AddAsync(Flight flight)
		{
			await _context.Flights.AddAsync(flight);
		}

		public void Update(Flight flight)
		{
			_context.Flights.Update(flight);
		}

		public void Remove(Flight flight)
		{
			_context.Flights.Remove(flight);
		}
    }
}