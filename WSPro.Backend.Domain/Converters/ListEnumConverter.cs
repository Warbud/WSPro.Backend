using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WSPro.Backend.Domain.Converters
{
    public class ListEnumConverter<T> : ValueConverter<IEnumerable<T>, string> where T : struct
    {
        public ListEnumConverter() : base(e => ListToString(e),
            e => StringToList(e))
        {
        }

        public static string ListToString(IEnumerable<T> value)
        {
            if (value == null || !value.Any()) return "";
            return string.Join(',', value);
        }

        public static IEnumerable<T> StringToList(string value)
        {
            if (string.IsNullOrEmpty(value)) return new List<T>();
            return value.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(e => Enum.Parse<T>(e));
        }
    }
}