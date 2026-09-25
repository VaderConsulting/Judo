using System;
using System.Data;
using System.IO;
using System.Linq;

namespace Library
{
    public static class Utilities
    {
        public static DataTable ReadCSV(string filePath, string[] SplitCharacters, bool WithHeaders)
        {
            DataTable dt = new DataTable();

            if (WithHeaders)
            {
                // Create the columns from the first row
                File.ReadLines(filePath).Take(1)
                    .SelectMany(x => x.Split(SplitCharacters, StringSplitOptions.None))
                    .ToList()
                    .ForEach(x => dt.Columns.Add(x.Trim()));
            }
            else
            {
                // Create the columns with generic names
                File.ReadLines(filePath).Take(1)
                    .SelectMany(x => x.Split(SplitCharacters, StringSplitOptions.None))
                    .ToList()
                    .ForEach(x => dt.Columns.Add("Column " + (dt.Columns.Count + 1).ToString()));
            }

            // Add the rows
            File.ReadLines(filePath).Skip(1)
                .Select(x => x.Split(SplitCharacters, StringSplitOptions.None))
                .ToList()
                .ForEach(line => dt.Rows.Add(line));
            return dt;
        }
    }
}
