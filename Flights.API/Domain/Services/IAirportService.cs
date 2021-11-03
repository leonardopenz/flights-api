using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Services.Communication;

namespace Flights.API.Domain.Services
{
    public interface IAirportService
    {
         Task<IEnumerable<Airport>> ListAsync();
         Task<AirportResponse> SaveAsync(Airport flight);
         Task<AirportResponse> UpdateAsync(int id, Airport flight);
         Task<AirportResponse> DeleteAsync(int id);
    }
}