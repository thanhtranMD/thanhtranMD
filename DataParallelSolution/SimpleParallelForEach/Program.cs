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
            const string welcomeText = "Welcome to Task Parallel Library Examples";
            Console.WriteLine(welcomeText);
            Console.WriteLine("-".PadRight(welcomeText.Length));
            string selectedMenu;
            do
            {
                Console.WriteLine("Select a menu:");
                Console.WriteLine("1 - MShow directory size example");
                Console.WriteLine("2 - Multiply Matrices example");
                Console.WriteLine("Q or q to Quit.");
                selectedMenu = Console.ReadLine();
                switch (selectedMenu)
                {
                    case "1":
                        DirectorySizeExample.ShowDirectoryTotalSize();
                        break;
                    case "2":
                        MultiplyMatrices.ExecMultiplyMatrices(args);
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            } while (selectedMenu.ToLower() != "q");
            Console.WriteLine("Enter any key to quit.");
            Console.ReadLine();
        }


    }
}
