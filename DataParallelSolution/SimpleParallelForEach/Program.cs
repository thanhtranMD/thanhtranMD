using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParallelForEach
{
    class Program
    {
        static void Main(string[] args)
        {
            //String[] args = Environment.GetCommandLineArgs();
            string cont = "";
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
                    DirectorySizeExample dir = new DirectorySizeExample();
                    dir.ShowDirectoryTotalSize(dirPath);
                }
                Console.WriteLine("Continue y/n?");
                cont = Console.ReadLine();
            }
            while (cont == "y" || cont.ToUpper() == "Y");
        }
    }
}
