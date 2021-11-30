using HotChocolate;
using HotChocolate.Types;

namespace WSPro.Backend.Shared.Importers
{
    public class ParsedValue
    {
        public ParsedValue(object? value, string? errorMessage = null)
        {
            Value = value;
            ErrorMessage = errorMessage;
            IsValid = errorMessage is null;
        }

        public bool IsValid { get; set; }
        public string? ErrorMessage { get; set; }
        [GraphQLType(typeof(AnyType))]
        public object? Value { get; set; }
    }
}