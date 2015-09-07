using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Partitioning_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] countries = { "Ukraine", "Australia", "Canada", "UK", "Germany", "USA", "Italy", "Poland" };
            IEnumerable<string> res = countries
                //.TakeWhile(s => s.Length > 2)
                .SkipWhile(s => s.Length > 2)
                //.Skip(-3)
                ;



            foreach (var c in res)
            {
                Console.WriteLine(c);
            }
        }
    }
}
