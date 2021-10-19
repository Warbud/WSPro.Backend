using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Application.Interfaces
{
    public interface ILevelService
    {
        Task<Level> GetByIdAsync(GetLevelDto data);
        Task<IQueryable<Level>> GetAllLevelsAsync();
        Task<Level> CreateAsync(CreateLevelDto data, CancellationToken cancellationToken);
        Task<Level[]> CreateManyAsync(CreateLevelDto[] data, CancellationToken cancellationToken);
        Task<Level> UpdateAsync(GetLevelDto input,CreateLevelDto data, CancellationToken cancellationToken);
        Task<Level> DeleteAsync(GetLevelDto input, CancellationToken cancellationToken);
    }
}