using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleParallelForEach
{
    public class DirectorySizeExample
    {
        public static void ShowDirectoryTotalSize()
        {
            string cont;
            do
            {
                Console.WriteLine("Enter a folder path to get total size.");
                string dirPath = Console.ReadLine();
                if (!Directory.Exists(dirPath))
                {
                    Console.WriteLine("The directory does not exist.");
                }
                else
                {
                    Console.WriteLine("Using parallel task");
                    ShowTotalSizeParallel(dirPath);
                    Console.WriteLine("Using normal sequential task");
                    ShowTotalSizeSequential(dirPath);
                }
                Console.WriteLine("Continue y/n?");
                cont = Console.ReadLine();
            }
            while (cont == "y" || cont.ToUpper() == "Y");


        }
        private static long ShowTotalSizeParallel(string dirPath)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long totalSize = 0;
            int filesSkipped = 0;
            String[] files = Directory.GetFiles(dirPath,"*.*", SearchOption.AllDirectories);
            Parallel.For(0, files.Length,
                         index => {
                             try
                             {
                                 FileInfo fi = new FileInfo(files[index]);
                                 long size = fi.Length;
                                 Interlocked.Add(ref totalSize, size);
                             }
                             catch (Exception)
                             {
                                 Interlocked.Increment(ref filesSkipped);
                             }
                         });
            Console.WriteLine("Directory '{0}':", dirPath);
            Console.WriteLine("Files skipped {0}:", filesSkipped);
            Console.WriteLine("{0:N0} files, {1:N0} bytes. {2} s", files.Length, totalSize, sw.Elapsed.TotalSeconds);
            sw.Stop();
            return totalSize;
        }

        private static long ShowTotalSizeSequential(string dirPath)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long totalSize = 0;
            int filesSkipped = 0;
            String[] files = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories);
            for(int index=0;index < files.Length;index++)
            {
                try
                {
                    FileInfo fi = new FileInfo(files[index]);
                    totalSize += fi.Length;
                }
                catch (Exception)
                {
                    filesSkipped++;
                }
            }

            Console.WriteLine("Directory '{0}':", dirPath);
            Console.WriteLine("Files skipped {0}:", filesSkipped);
            Console.WriteLine("{0:N0} files, {1:N0} bytes. {2} s", files.Length, totalSize, sw.Elapsed.TotalSeconds);
            sw.Stop();
            return totalSize;
        }
    }
}
