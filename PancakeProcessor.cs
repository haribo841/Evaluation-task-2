using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Evaluation_task_2
{
    internal class PancakeProcessor
    {
        public DataTable ProcessData(IEnumerable<IGrouping<DateTime, PancakeData>> groupedData)
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("Data_i_godzina", typeof(DateTime));
            resultTable.Columns.Add("mąka (kg)", typeof(double));
            resultTable.Columns.Add("kasza (kg)", typeof(double));
            resultTable.Columns.Add("mleko (l)", typeof(double));
            resultTable.Columns.Add("jajka (sztuki)", typeof(int));

            foreach (var item in groupedData)
            {
                resultTable.Rows.Add(item.Key,
                                     item.Sum(r => Convert.ToDouble(r.FLOUR) / 100),  // Convert dkg to kg
                                     item.Sum(r => Convert.ToDouble(r.GROAT) / 1000),  // Convert g to kg
                                     item.Sum(r => Convert.ToDouble(r.MILK) / 1000),   // Convert ml to l
                                     item.Sum(r => r.EGG));
            }

            return resultTable;
        }
    }
}