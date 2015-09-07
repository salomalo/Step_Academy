using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandartOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            //Определяем массив из 10 чисел
            int[] Mas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Выбераем из массива первых 4 элемента
            //var Mas1 = Mas.Take(4); 
            var Mas1 = Mas.Skip(4); //Пропускаем первые 4 элемента
            //var Mas1 = Mas.TakeWhile(i => i <= 3);
            foreach (var n in Mas1)
            {
                Console.WriteLine(n);
            }
        }
    }
}
