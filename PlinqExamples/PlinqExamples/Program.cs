using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlinqExamples
{
    class Program
    {
        public static void Main()
        {
            Execute1();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine();
        }

        static void DoSomething(int e) 
        {
            Console.WriteLine("{0} - thread:{1}", e, Thread.CurrentThread.ManagedThreadId);
        }

        static IEnumerable<int> GetRandomNumberList(int capacity)
        {
            var r = new Random();
            var myValues = Enumerable.Range(0, (capacity/10)).ToList(); // Will work with array or list
            return Enumerable.Range(0, capacity)
                .Select(e => myValues[r.Next(myValues.Count)]);
             
        }

        static ConcurrentBag<int> GenerateDistinctConcurrentBag(IEnumerable<int> source)
        {
            ConcurrentBag<int> list = new ConcurrentBag<int>();
            var pquery = source.AsParallel().Distinct();
            pquery.ForAll(i => list.Add(i));

            return list;
        }
        static ConcurrentBag<int> GenerateDistinctConcurrentBag2(IEnumerable<int> source)
        {
            
            ConcurrentBag<int> list = new ConcurrentBag<int>();
            //
            var distinctlist = source.Distinct();
            Parallel.ForEach(distinctlist, number =>
            {
                list.Add(number);
            });

            return list;
        }
        static List<int> GetDistinctList(IEnumerable<int> source)
        {
            return source.Distinct().ToList();
        }
        static void WriteToFile(List<int> source, string filePath)
        {
            StringBuilder sb = new StringBuilder(source.Count);
            foreach(int i in source)
            {
                sb.AppendLine(i.ToString());
            }
            File.WriteAllText(filePath,sb.ToString());
        }
        static void Execute1()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int capacity=2000;
            string input = "";
            do
            {
                var source = GetRandomNumberList(Convert.ToInt32(capacity));
                sw.Restart();
                for(int i=0; i<=50; i++)
                {
                    Console.WriteLine("{0} - {1}", i, source.Distinct().Count());
                }
                //Console.WriteLine($"Begin generated normal distinct list");
                //List<int> list0 = GetDistinctList(source);
                //Console.WriteLine($"Finished generated distinct Count:{list0.Count} {sw.ElapsedMilliseconds} ms.");
                //WriteToFile(list0, @"C:\temp\file1.txt");
                //sw.Restart();
                //Console.WriteLine($"Begin generated concurrent bag of number list using Parallel.ForEach.");
                //ConcurrentBag<int> list = GenerateDistinctConcurrentBag(source);
                //Console.WriteLine($"Finished generated concurrent bag of number list using Parallel.ForEach. Count:{list.Count} {sw.ElapsedMilliseconds} ms.");
                //WriteToFile(list.ToList(), @"C:\temp\file2.txt");
                //sw.Restart();
                //Console.WriteLine($"Begin generated concurrent bag of number list using PLINQ.");
                //ConcurrentBag<int> list2 = GenerateDistinctConcurrentBag(source);
                //Console.WriteLine($"Finished generated concurrent bag of number list using PLINQ. Count:{list2.Count} {sw.ElapsedMilliseconds} ms.");
                //WriteToFile(list2.ToList(), @"C:\temp\file3.txt");

                Console.WriteLine("Enter capacity:");
                input = Console.ReadLine();
            } while (int.TryParse( input, out capacity));
            sw.Stop();
        }

        static void Execute2()
        {
            var source = Enumerable.Range(100, 20000);

            // Result sequence might be out of order.
            var parallelQuery =
                from num in source.AsParallel()
                where num % 10 == 0
                select num;

            // Process result sequence in parallel
            parallelQuery.ForAll((e) => DoSomething(e));

            // Or use foreach to merge results first.
            foreach (var n in parallelQuery)
            {
                Console.WriteLine(n);
            }

            // You can also use ToArray, ToList, etc as with LINQ to Objects.
            var parallelQuery2 =
                (from num in source.AsParallel()
                 where num % 10 == 0
                 select num).ToArray();

            // Method syntax is also supported
            var parallelQuery3 =
                source.AsParallel()
                    .Where(n => n % 10 == 0)
                    .Select(n => n);

        }
    }
}
