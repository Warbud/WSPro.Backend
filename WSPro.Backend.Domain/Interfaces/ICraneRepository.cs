using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Domain.Interfaces
{
    public interface ICraneRepository
    {
        IQueryable<Crane> GetAllAsync();
        Task<Crane> GetByIdAsync(int id);
        Task<Crane> CreateAsync(string name);
        Task<Crane[]> CreateRangeAsync(string[] names);
        Task<Crane> UpdateAsync(int currentCraneId, string newName);
        Task<Crane> DeleteAsync(int id);
    }
}