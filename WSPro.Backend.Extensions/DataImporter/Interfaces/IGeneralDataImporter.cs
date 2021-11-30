using System.Collections.Generic;
using System.Threading.Tasks;
using WSPro.Backend.Extensions.DataImporter.Modules.WorkProgress;
using WSPro.Backend.Extensions.DataReader;
using WSPro.Backend.Shared.Importers;

namespace WSPro.Backend.Extensions.DataImporter.Interfaces
{
    public interface IGeneralDataImporter : IDataImporter
    {
        Task WithProject(int projectId);
        
        Task WithData(Csv data);
    }
}