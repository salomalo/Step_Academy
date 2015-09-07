using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skip_and_Reverse
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Определяем массив из 10 чисел
            int[] Mas = { 1, 2, 3, 4, 5, 2, 3, 8, 9, 10 };
            //Пропускаем элементы, пока выполняется условие
            //var Mas1 = Mas.SkipWhile(i => i <= 4);
            //Переворачиваем массив
            var Mas1 = Mas.Reverse();
            foreach (var num in Mas1)
            {
                Console.WriteLine(num);
            }

            
           
        }
    }
}
