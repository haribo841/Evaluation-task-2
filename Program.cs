using System;
using System.Data;
using CsvHelper;
using System.Globalization;
using System.Collections.Generic;
using CsvHelper.Configuration;
using System.Collections;

namespace Evaluation_task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Adam\\Desktop\\test.csv";
            ICsvReader csvReader = new CsvDataReader();
            DataAnalyzer dataAnalyzer = new();
            PancakeProcessor pancakeProcessor = new();
            DataService dataService = new(csvReader, pancakeProcessor, dataAnalyzer);
            List<IngredientUsage> result = dataService.ProcessCsvFile(filePath, csvReader) ?? new List<IngredientUsage>();
            switch (result)
            {
                case null:
                    Console.WriteLine("Błąd podczas przetwarzania danych.");
                    break;
                default:
                    {
                        string outputFilePath = "C:\\Users\\Adam\\Desktop\\output.csv";
                        using (var writer = new StreamWriter(outputFilePath))
                        using (CsvWriter csv = new(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                        {
                            SumResult sumResults = new();
                            IEnumerable<IngredientUsage> summedResults = (IEnumerable<IngredientUsage>)sumResults.SumResults(result);
                            csv.WriteRecords(summedResults);
                        }
                        Console.WriteLine("Wyniki zostały zapisane do pliku output.csv.");
                        break;
                    }
            }
        }
    }
}