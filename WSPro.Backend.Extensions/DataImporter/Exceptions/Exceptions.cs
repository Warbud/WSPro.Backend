using System;

namespace WSPro.Backend.Extensions.DataImporter.Exceptions
{
    public class NotContainException : Exception
    {
        public NotContainException(string message) : base(message)
        {
        }
    }

    public class NotValidImportException : Exception
    {
        public NotValidImportException(string message) : base(message)
        {
        }
    }
}