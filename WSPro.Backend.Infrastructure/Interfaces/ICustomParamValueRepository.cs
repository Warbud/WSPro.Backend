using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.Interfaces
{
    public interface ICustomParamValueRepository
    {
        Task<bool> ExistAsync(int customParamsId, int elementId );
        Task<IQueryable<CustomParamValue>> GetAllAsync();
        Task<IQueryable<CustomParamValue>> GetByIdAsync(int customParamsId, int elementId);
        Task<IQueryable<CustomParamValue>> CreateAsync(CustomParamValue item);
        // Task<IQueryable<CustomParamValue>> UpdateAsync(CustomParamValue item);
        Task UpdateAsync(CustomParamValue item);
        Task DeleteAsync(CustomParamValue item);
    }
}