using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace WSPro.Backend.Extensions.DataReader
{
    public class Csv
    {
        public List<string> Headers { get; set; } = new();
        public List<List<string>> Data { get; set; } = new();
        private string RawCsv { get; set; }
        private CsvParserOptions _options { get; }
        public Csv(string csv,CsvParserOptions options)
        {
            _options = options;
            RawCsv = csv;
        }
        public Csv ParseCsv()
        { 
            // To use the TextFieldParser a reference to the Microsoft.VisualBasic assembly has to be added to the project. 
            using (TextFieldParser parser = new(new StringReader(RawCsv))) 
            {
                parser.CommentTokens = new string[] { "#" };
                parser.SetDelimiters(_options.Delimiter);
                parser.HasFieldsEnclosedInQuotes = true;
                
                Headers.AddRange(parser.ReadFields() ?? Array.Empty<string>());

                while (!parser.EndOfData)
                {
                    var values = new List<string>();
                    var readFields = parser.ReadFields();
                    if (readFields != null)
                        values.AddRange(readFields);
                    Data.Add(values);
                }
            }

            return this;
        }
    }
}