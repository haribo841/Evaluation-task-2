using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Evaluation_task_2;

namespace Evaluation_task_2
{
    internal class DataService
    {
        private readonly ICsvReader csvReader;
        private readonly PancakeProcessor pancakeProcessor;
        public DataService(ICsvReader csvReader, PancakeProcessor pancakeProcessor)
        {
            this.csvReader = csvReader;
            this.pancakeProcessor = pancakeProcessor;
        }
        public (List<PancakeData>, DataTable) ProcessCsvFile(string filePath)
        {
            List<PancakeData> data = csvReader.ReadCsvFile(filePath);

            // Przetworzenie danych
            IEnumerable<IGrouping<DateTime, PancakeData>> groupedData = GroupData(data);
            DataTable resultTable = pancakeProcessor.ProcessData(groupedData);

            return (data, resultTable); // Zwracamy zarówno dane wejściowe, jak i resultTable
        }
        private IEnumerable<IGrouping<DateTime, PancakeData>> GroupData(List<PancakeData> data)
        {
            var groupedData = data.GroupBy(row => new
            {
                row.TIMESTAMP.Date,
                row.TIMESTAMP.Hour
            });

            return (IEnumerable<IGrouping<DateTime, PancakeData>>)groupedData;
        }
    }
}