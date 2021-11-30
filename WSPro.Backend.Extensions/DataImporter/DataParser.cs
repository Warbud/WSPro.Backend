using System;
using System.Linq;

namespace WSPro.Backend.Extensions.DataImporter
{
    public interface IParser<T>
    {
        T Parse(string value);
    }

    public class DataParser
    {
        public class Bool : IParser<bool>
        {
            public bool Parse(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return false;

                string[] trueValues =
                {
                    "1",
                    "true"
                };

                return trueValues.Contains(value.ToLower());
            }
        }

        public class Date : IParser<DateTime>
        {
            public DateTime Parse(string value)
            {
                return DateTime.Parse(value);
            }
        }

        public class Decimal : IParser<decimal>
        {
            public decimal Parse(string value)
            {
                return decimal.Parse(value);
            }
        }
        public class Integer : IParser<int>
        {
            public int Parse(string value)
            {
                return int.Parse(value);
            }
        }
    }
}