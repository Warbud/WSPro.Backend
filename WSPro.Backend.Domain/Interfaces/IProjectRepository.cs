using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<bool> ProjectExistAsync(Project project);
        Task<IQueryable<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(Project project);
        Task<Project> CreateAsync(Project project);
        Task<Project> UpdateAsync(Project project);
        Task<Project> DeleteAsync(Project project);
    }
}