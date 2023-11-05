using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace Evaluation_task_2
{
    internal class CsvDataReader : ICsvReader
    {
        public List<PancakeData> ReadCsvFile(string filePath)
        {
            List<PancakeData> records = new List<PancakeData>();

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.Context.RegisterClassMap<PancakeDataMap>();
                records = csv.GetRecords<PancakeData>().ToList();
            }

            return records;
        }

    }
}