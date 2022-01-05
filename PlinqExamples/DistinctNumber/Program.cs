using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 2000;
            string input = "";
            do
            {
                var source = GetRandomNumberList(Convert.ToInt32(capacity));
                for (int i = 0; i <= 50; i++)
                {
                    Console.WriteLine("{0} - {1}", i, source.Distinct().Count());
                }
                Console.WriteLine("Enter capacity:");
                input = Console.ReadLine();
            } while (int.TryParse(input, out capacity));

        }

        static IEnumerable<int> GetRandomNumberList(int capacity)
        {
            var r = new Random(capacity / 10);
            //var myValues = Enumerable.Range(0, (capacity / 10)).ToList(); // Will work with array or list
            return Enumerable.Range(0, capacity)
                .Select(e => r.Next());

        }
    }
}
