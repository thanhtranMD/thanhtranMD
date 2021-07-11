using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine("MShow directory size example");
            DirectorySizeExample.ShowDirectoryTotalSize();

            Console.WriteLine("Multiply Matrices example");
            MultiplyMatrices.ExecMultiplyMatrices(args);
        }


    }
}
