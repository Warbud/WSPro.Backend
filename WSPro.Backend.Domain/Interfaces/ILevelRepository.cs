using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Domain.Interfaces
{
    public interface ILevelRepository
    {
        Task<bool> LevelExistAsync(Level level);
        Task<IQueryable<Level>> GetAllAsync();
        Task<Level> GetByIdAsync(Level level);
        Task<Level> CreateAsync(Level level);
        Task<Level[]> CreateRangeAsync(Level[] levels);
        Task<Level> UpdateAsync(Level updatedLevel);
        Task<Level> DeleteAsync(Level level);
    }
}