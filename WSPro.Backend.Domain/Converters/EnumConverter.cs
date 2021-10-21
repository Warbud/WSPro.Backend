using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WSPro.Backend.Domain.Converters
{
    public class EnumConverter<T> where T : struct
    {
        public ValueConverter Converter = new ValueConverter<T, string>(
            v => v.ToString(),
            v => Enum.Parse<T>(v)
        );
    }
}