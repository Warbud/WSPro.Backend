using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.Interfaces
{
    public interface ICustomParamProjectRepository
    {
        Task<bool> ExistAsync(int customParamsId, int projectId );
        Task<IQueryable<CustomParamProject>> GetAllAsync();
        Task<IQueryable<CustomParamProject>> GetByIdAsync(int customParamsId, int projectId);
        Task<IQueryable<CustomParamProject>> CreateAsync(CustomParamProject item);
        // Task<IQueryable<CustomParamProject>> UpdateAsync(CustomParamProject item);
        Task DeleteAsync(CustomParamProject item);
    }
}