using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtentionMethods2
{
    static class PrintArrays
    {
        public static void Print(this IEnumerable<int> mas)
        {
            Console.WriteLine();
            foreach (var i in mas)
            {
                Console.Write("{0} ",i);
            }
        }

        public static void Sort(this IEnumerable<int> mas)
        {
            var mas1 = from t in mas
                       orderby t
                       select t;
            mas = mas1;

            Console.WriteLine("Массив отсортирован");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
             
            IEnumerable<int> mas1 = new int[10] { 0, 3, 4, 1, 10, 8, 21, 4, 7, 2 };
            var mas2 = new List<int>();

            mas2.Add(8);
            mas2.Add(1);
            mas2.Add(2);

            mas1.Print();
            mas2.Print();
            mas1.Sort(); //вызывается расширяющий метод
            mas2.Sort(); //вызывается стандартный метод сортировки List
            mas1.Print();
            mas2.Print();

           // PrintArrays.Print(mas1);

        }
        
    }
}
