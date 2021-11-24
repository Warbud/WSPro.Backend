using System.IO;
using HotChocolate.Types;

namespace WSPro.Backend.Extensions.Files.Reader
{
    public interface IFileReader
    {
        public bool IsValidExtension { get; }
    }

    public class CsvReader : IFileReader
    {
        public bool IsValidExtension { get; }
        private readonly IFile _file;

        public CsvReader(IFile file)
        {
            _file = file;
            IsValidExtension = IsValid(file.Name);
        }

        public Stream AsStream()
        {
            return _file.OpenReadStream();
        }

        private bool IsValid(string fileName)
        {
            return Path.GetExtension(fileName) == "csv";
        }
    }
}