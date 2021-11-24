using System.Threading.Tasks;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.Interfaces
{
    public interface ICraneRepository : IBaseOperations<Crane>
    {
        Task<Crane[]> CreateRangeAsync(Crane[] cranes);
    }
}