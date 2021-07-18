using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleParallelForEach
{
    public class ActionExample:IMenuItem
    {
        public ActionExample() { }
        public ActionExample(int index)
        {
            Index = index;
        }
        public int Index { get; set; }

        public string Name { get { return "Action example."; } }
        public void Run()
        {
            List<String> names = new List<String>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");

            // Display the contents of the list using the Print method.
            names.ForEach(Print);

            // The following demonstrates the anonymous method feature of C#
            // to display the contents of the list to the console.
            names.ForEach(delegate (String name)
            {
                Console.WriteLine(name);
            });

            void Print(string s)
            {
                Console.WriteLine(s);
            }

            /* This code will produce output similar to the following:
            * Bruce
            * Alfred
            * Tim
            * Richard
            * Bruce
            * Alfred
            * Tim
            * Richard
            */
        }
    }
}
