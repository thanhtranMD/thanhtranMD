using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleParallelForEach
{
    public enum ParallelRunMode
    {
        ForEach,
        ForEachWithLocal,
    }
    public class ParallelExamples : IMenuItem
    {
        public ParallelExamples() { }

        public ParallelExamples(int index)
        {
            Index = index;
            Mode = ParallelRunMode.ForEach;
        }
        public ParallelExamples(ParallelRunMode mode)
        {
            Mode = mode;
        }
        public ParallelExamples(int index,ParallelRunMode mode)
        {
            Index = index;
            Mode = mode;
        }

        public ParallelRunMode Mode { get; set; }

        public int Index { get; set; }

        public string Name 
        { 
            get 
            {
                switch(Mode)
                {
                    case ParallelRunMode.ForEach:
                        return "Parallel ForEach example.";
                    case ParallelRunMode.ForEachWithLocal:
                        return "Parallel ForEach with thread local example.";
                }
                return "no idea!";
            } 
        }

        public void Run()
        {
            switch(Mode)
            {
                case ParallelRunMode.ForEach:
                    ParallelForEachExample();
                    break;
                case ParallelRunMode.ForEachWithLocal:
                    RunForEachThreadLocal();
                    break;
            }
                
        }

        public static void ParallelForEachExample()
        {
            // 2 million
            var limit = 2_000_000;
            var numbers = Enumerable.Range(0, limit).ToList();

            var watch = Stopwatch.StartNew();
            var primeNumbersFromForeach = GetPrimeList(numbers);
            watch.Stop();

            var watchForParallel = Stopwatch.StartNew();
            var primeNumbersFromParallelForeach = GetPrimeListWithParallel(numbers);
            watchForParallel.Stop();

            Console.WriteLine($"Classical foreach loop | Total prime numbers : {primeNumbersFromForeach.Count} | Time Taken : {watch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"Parallel.ForEach loop  | Total prime numbers : {primeNumbersFromParallelForeach.Count} | Time Taken : {watchForParallel.ElapsedMilliseconds} ms.");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// GetPrimeList returns Prime numbers by using sequential ForEach
        /// </summary>
        /// <param name="inputs"></param>
        /// <returns></returns>
        private static IList<int> GetPrimeList(IList<int> numbers) => numbers.Where(IsPrime).ToList();

        /// <summary>
        /// GetPrimeListWithParallel returns Prime numbers by using Parallel.ForEach
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private static IList<int> GetPrimeListWithParallel(IList<int> numbers)
        {
            var primeNumbers = new ConcurrentBag<int>();

            Parallel.ForEach(numbers, number =>
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            });

            return primeNumbers.ToList();
        }

        /// <summary>
        /// IsPrime returns true if number is Prime, else false.(https://en.wikipedia.org/wiki/Prime_number)
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void RunForEachThreadLocal()
        {
            int[] nums = Enumerable.Range(0, 1000000).ToArray();
            long total = 0;
            // First type parameter is the type of the source elements
            // Second type parameter is the type of the thread-local variable (partition subtotal)
            Parallel.ForEach<int, long>(nums, // source collection
                                        () => 0, // method to initialize the local variable
                                        (j, loop, subtotal) => // method invoked by the loop on each iteration
                                        {
                                            subtotal += j; //modify local variable
                                            return subtotal; // value to be passed to next iteration
                                        },
                                        // Method to be executed when each partition has completed.
                                        // finalResult is the final value of subtotal for a particular partition.
                                        (finalResult) => Interlocked.Add(ref total, finalResult)
                                        );

            Console.WriteLine("The total from Parallel.ForEach is {0:N0}", total);
        }
    }

}
