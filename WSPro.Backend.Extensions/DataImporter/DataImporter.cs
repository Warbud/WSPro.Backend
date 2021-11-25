using System.Collections.Generic;
using WSPro.Backend.Extensions.DataReader;
using WSPro.Backend.Shared.Enum;
using WSPro.Backend.Shared.Input;

namespace WSPro.Backend.Extensions.DataImporter
{
    public class DataImporter
    {
        private readonly UploadInput _input;

        public DataImporter(UploadInput input)
        {
            _input = input;
        }

        public void ReadData()
        {
            if (_input.DataType == DataImportType.Csv && _input.DataType == DataImportType.Csv)
            {
                var data = new Csv(_input.Value,new CsvParserOptions()).ParseCsv();
            }
        }
    }
}