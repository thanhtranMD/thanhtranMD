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
        private static List<IMenuItem> MenuItems;
        static void Main(string[] args)
        {
            PopulateMenuItems();
            const string welcomeText = "Welcome to Task Parallel Library Examples";
            Console.WriteLine(welcomeText);
            Console.WriteLine("-".PadRight(welcomeText.Length));
            string selectedMenu;
            while (true)
            {
                int menuNo;
                Console.WriteLine("Select a menu:");
                MenuItems.ForEach(delegate (IMenuItem item) { Console.WriteLine("{0} - {1}.", item.Index, item.Name); });
                
                Console.WriteLine("Enter non-numeric to Quit.");
                selectedMenu = Console.ReadLine();
                if (int.TryParse(selectedMenu, out menuNo))
                {
                    if (menuNo != 0 && menuNo <= MenuItems.Count)
                    {
                        MenuItems[menuNo-1].Run();
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
                else
                {
                    break;
                }
            } 
            Console.WriteLine("Enter any key to quit.");
            Console.ReadLine();
        }

        private static void RegisterMenuItem(IMenuItem item)
        {
            MenuItems.Add(item);
        }

        private static void PopulateMenuItems()
        {
            if(MenuItems == null)
            {
                MenuItems = new List<IMenuItem>();
            }
            RegisterMenuItem(new DirectorySizeExample(1));
            RegisterMenuItem(new MultiplyMatrices(2));
            RegisterMenuItem(new ParallelExamples(3));
            RegisterMenuItem(new FuncExample(4));
            RegisterMenuItem(new ActionExample(5));
        }
    }
}
