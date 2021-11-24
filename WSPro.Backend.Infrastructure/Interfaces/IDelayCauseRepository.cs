using System.Threading.Tasks;
using WSPro.Backend.Domain.Helpers;
using WSPro.Backend.Domain.Model;

namespace WSPro.Backend.Infrastructure.Interfaces
{
    public interface IDelayCauseRepository : IBaseOperations<DelayCause>
    {
        void Attach(DelayCause item);
    }
}