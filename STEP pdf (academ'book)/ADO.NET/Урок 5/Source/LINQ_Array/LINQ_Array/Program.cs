using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             var i = 1;
  var s = "SomeString";
  var z = i + i * i;
  var c = 'c';

  Console.WriteLine(i.GetType()); // System.Int32
  Console.WriteLine(s.GetType()); // System.String
  Console.WriteLine(c.GetType()); // System.Char
  Console.WriteLine(z.GetType()); // System.Int32

             */
            /*  //Определяем массив чисел
            int[] Mas = {1,2,3,4,5,6,7,8,9,10}; 
            //Выполняем запрос к массиву Mass и получим его элементы, которые больше 4, но меньше 8
            var Mas1 = from i in Mas
            where i > 4 && i < 8
            select i; 
            foreach (var val in Mas1)
            Console.WriteLine(val);
           */
            //Определяем массив чисел
            int[] Mas = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Выполняем запрос к массиву Mas и выполняем преобразование в объект 
            //содержащий два поля Value - число и
            //Even значение boolean показывающее является ли число четным
            var Mas1 = from i in Mas
                           select new { Value = i, Even = (i % 2 == 0) };
            foreach (var val in Mas1)
                Console.WriteLine("{0} - {1}", val.Value, val.Even);

        }

        
    }
}
