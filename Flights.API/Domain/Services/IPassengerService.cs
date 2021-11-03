using System.Collections.Generic;
using System.Threading.Tasks;
using Flights.API.Domain.Models;
using Flights.API.Domain.Services.Communication;

namespace Flights.API.Domain.Services
{
    public interface IPassengerService
    {
         Task<IEnumerable<Passenger>> ListAsync();
         Task<PassengerResponse> SaveAsync(Passenger passenger);
         Task<PassengerResponse> UpdateAsync(string passport, Passenger passenger);
         Task<PassengerResponse> DeleteAsync(string passport);
    }
}