using System.Threading.Tasks;

namespace Flights.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}