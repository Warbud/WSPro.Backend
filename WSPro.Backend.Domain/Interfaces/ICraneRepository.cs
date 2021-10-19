using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Domain.Interfaces
{
    public interface ICraneRepository
    {
        Task<bool> CraneExistAsync(Crane crane);
        Task<IQueryable<Crane>> GetAllAsync();
        Task<Crane> GetByIdAsync(int id);
        Task<Crane> CreateAsync(Crane crane);
        Task<Crane[]> CreateRangeAsync(Crane[] cranes);
        Task<Crane> UpdateAsync(Crane updatedCrane);
        Task<Crane> DeleteAsync(Crane crane);
    }
}