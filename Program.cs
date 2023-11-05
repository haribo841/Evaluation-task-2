using System.Data;

namespace Evaluation_task_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Adam\\Desktop\\Zeszyt2.csv"; // actual file path

            ICsvReader csvReader = new CsvDataReader();
            PancakeProcessor pancakeProcessor = new PancakeProcessor();
            DataService dataService = new DataService(csvReader, pancakeProcessor);

            (List<PancakeData> data, DataTable resultTable) = dataService.ProcessCsvFile(filePath);

            // processed data in 'data' and the result table in 'resultTable'.
            // I dont use it yet
            // print the result table to the console:
            foreach (DataRow row in resultTable.Rows)
            {
                Console.WriteLine($"{row["Data_i_godzina"]}, mąka: {row["mąka (kg)"]} kg, kasza: {row["kasza (kg)"]} kg, mleko: {row["mleko (l)"]} l, jajka: {row["jajka (sztuki)"]} szt.");
            }
        }
    }
}