using System.Collections.Generic;

namespace WSPro.Backend.Extensions.DataImporter.Interfaces
{
    public interface IDataImporter
    {
        public Dictionary<string,int> Created { get; set; }
        public Dictionary<string,int> Updated { get; set; }

        IDataImporter Validate();
        IDataImporter Import();
    }
}