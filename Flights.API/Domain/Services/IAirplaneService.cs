using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Services.Communication;

namespace Flights.API.Domain.Services
{
    public interface IAirplaneService
    {
         Task<IEnumerable<Airplane>> ListAsync();
         Task<AirplaneResponse> SaveAsync(Airplane airplane);
         Task<AirplaneResponse> UpdateAsync(int id, Airplane airplane);
         Task<AirplaneResponse> DeleteAsync(int id);
    }
}