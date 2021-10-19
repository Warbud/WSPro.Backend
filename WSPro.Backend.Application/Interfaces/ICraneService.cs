using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Model.V1;

namespace WSPro.Backend.Application.Interfaces
{
    public interface ICraneService
    {
        Task<Crane> GetCraneByID(GetCraneDto data);
        Task<IQueryable<Crane>> GetAllCranes();
        Task<Crane> CreateAsync(CreateCraneDto data,CancellationToken cancellationToken);
        Task<Crane[]> CreateManyAsync(CreateCraneDto[] data, CancellationToken cancellationToken);
        Task<Crane> UpdateAsync(GetCraneDto input, CreateCraneDto data, CancellationToken cancellationToken);
        Task<Crane> DeleteAsync(GetCraneDto input, CancellationToken cancellationToken);
    }
}