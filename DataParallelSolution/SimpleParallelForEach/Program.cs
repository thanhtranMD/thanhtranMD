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
            item.Index = MenuItems.Count + 1; // set menu index based on the last added entry index
            MenuItems.Add(item);
        }

        private static void PopulateMenuItems()
        {
            if(MenuItems == null)
            {
                MenuItems = new List<IMenuItem>();
            }
            RegisterMenuItem(new DirectorySizeExample());
            RegisterMenuItem(new MultiplyMatrices());
            RegisterMenuItem(new ParallelExamples());
            RegisterMenuItem(new ParallelExamples(ParallelRunMode.ForEachWithLocal));
            RegisterMenuItem(new FuncExample());
            RegisterMenuItem(new ActionExample());
        }
    }
}
