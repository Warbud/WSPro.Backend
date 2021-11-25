using System.Threading.Tasks;
using WSPro.Backend.Extensions.DataReader;

namespace WSPro.Backend.Extensions.DataImporter.Interfaces
{
    public interface IGeneralDataImporter : IDataImporter
    {
        Task WithProject(int projectId);
        Task Parse();
        Task WithData(Csv data);
    }
}