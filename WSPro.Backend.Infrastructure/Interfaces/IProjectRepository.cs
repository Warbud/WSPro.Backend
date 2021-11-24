using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.Interfaces
{
    public interface IProjectRepository : IBaseOperations<Project>
    {
        Task<IQueryable<Project>> GetByIdsAsync(int[] projectIds);
        Task AttachAsync(Project item);
    }
}