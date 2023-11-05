using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Evaluation_task_2
{
    internal class DataAnalyzer
    {
        public void AnalyzeData(List<IngredientUsage> result)
        {
            SumResult sumResult = new SumResult();
            IEnumerable<IngredientUsage> summedResults = (IEnumerable<IngredientUsage>)sumResult.SumResults(result);
            Console.WriteLine("TIMESTAMP\t\t\tFlour\tGroat\tMilk\tEgg");
            foreach (var item in summedResults)
            {
                Console.WriteLine($"{item.TIMESTAMP:yyyy-MM-dd HH:mm:ss zzz}\t{item.FLOUR:F1}\t{item.GROAT:F2}\t{item.MILK:F2}\t{item.EGG}");
            }
        }
    }
}