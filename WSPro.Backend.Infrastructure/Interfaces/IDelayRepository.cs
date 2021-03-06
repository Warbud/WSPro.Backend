using System.Linq;
using System.Threading.Tasks;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.Interfaces
{
    public interface IDelayRepository:IBaseOperations<Delay>
    {
        Task<IQueryable<Delay>> UpdateAsync(Delay item,UpdateDelayDto dto);
    }
}