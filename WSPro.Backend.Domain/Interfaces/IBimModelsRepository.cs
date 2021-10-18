using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Model;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Domain.Interfaces
{
    public interface IBimModelsRepository
    {
        IQueryable<BimModel> GetAllAsync();
        Task<BimModel> GetByIdAsync(int id);
        Task<BimModel> AddAsync();
        Task<BimModel> UpdateAsync();
        Task<BimModel> DeleteAsync(int id);
    }
}