using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_AggregateFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] numbers = { 1, 2, 3, 4, 5 };

            int res = numbers.Min();
            res = numbers.Where(x => x % 2 == 0).Max();

            res = numbers.Where(x => x % 2 != 0).Sum();
            res = numbers.Where(x => x % 2 != 0).Count();
            double resAvg = numbers.Where(x => x % 2 != 0).Average();

            // Console.WriteLine(resAvg);
            // 
            // string[] countries = { "Ukraine", "Poland", "USA", "UK" }; // "Ukraine, Poland, USA, UK"
            // 
            // string res2 = countries.FirstOrDefault( c => c.Length == countries.Max(bgg => bgg.Length));
            // 
            // string countriesConcat = countries.Aggregate( (a, b) => a + ", " + b);
            // 
            // Console.WriteLine(countriesConcat);

            Console.WriteLine(numbers.Aggregate((a, b) => a * b));
            Console.WriteLine(numbers.Aggregate(100500, (a, b) => a * b));


        }
    }
}
