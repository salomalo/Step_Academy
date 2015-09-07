using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferentCollections
{

    class Program
    {
        public static class Util
        {
          public static int ElementCount(IEnumerable enumerable)
          {
            int i = 0;
            foreach (var e in enumerable)
              i++;
            return i;
          }
        }


        static void Main(string[] args)
        {
            //var 
            IEnumerable<int> mas1 = new int[10] { 0, 3, 4, 1, 10, 8, 21, 4, 7, 2 };
            var mas2 = new List<float>();
           
            mas2.Add(8.1f);
            mas2.Add(1.7f);
            mas2.Add(2.0f);

            // И тогда, для любого массива
            IEnumerable<int> array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Можно было бы посчитать количество элементов
            Console.WriteLine(Util.ElementCount(array)); // 10

            //Print(mas1);
            //Print(mas2);
            //Sort(mas1);
            //Sort(mas2);
            //Print(mas1);
            //Print(mas2);

        }
        static void Print(IEnumerable  mas)
        {/*LINQ работает с любым типом набором данных, реализиющих интерфейс IQueriable*/
            foreach (var i in mas)
            {
                Console.WriteLine(i);
            }
        }
        
        
        static void Sort(IComparable[] mas)
        {/*Делаем требование к типу более жестким, т.к. нам нужно выполнять сравнение элементов массива*/ 
            bool sort;
            for (var i = 0; i < mas.Length; i++)
            {
                sort = true;
                for (var j = 0; j < mas.Length - 1; j++)
                {
                    if (mas[j].CompareTo(mas[j + 1])>0)
                    {
                        IComparable h = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = h;
                        sort = false;
                    }
                }
                if (sort == true) break;

            }
        }
    }
}
