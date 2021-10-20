using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Application.Interfaces
{
    public interface IProjectService
    {
        Task<Project> GetByIdAsync(GetProjectDto data);
        Task<IQueryable<Project>> GetAllAsync();
        Task<Project> CreateAsync(CreateProjectDto data, CancellationToken cancellationToken);
        Task<Project> UpdateAsync(GetProjectDto input, CreateProjectDto data, CancellationToken cancellationToken);
        Task<Project> DeleteAsync(GetProjectDto input, CancellationToken cancellationToken);
    }
}