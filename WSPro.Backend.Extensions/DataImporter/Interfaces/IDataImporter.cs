using System.Collections.Generic;
using System.Threading.Tasks;
using WSPro.Backend.Extensions.DataImporter.Modules.WorkProgress;
using WSPro.Backend.Shared.Importers;

namespace WSPro.Backend.Extensions.DataImporter.Interfaces
{
    public interface IDataImporter
    {
        public Dictionary<string,int> Created { get; set; }
        public Dictionary<string,int> Updated { get; set; }

        Task<ICollection<Dictionary<string, ParsedValue>>> Validate();
        Task<IDataImporter> Import();
    }
}