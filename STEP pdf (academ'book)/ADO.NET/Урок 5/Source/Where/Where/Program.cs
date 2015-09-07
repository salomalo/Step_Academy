using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Where
{
    class Program
    {
        static void Main(string[] args)
        {
            //Определяем массив из 10 чисел
            int[] Mas = { 1, 2, 3, 4, 5, 2, 3, 8, 9, 10 };
            //Отбираем элементы, удовлетворяющие условию
            var Mas1 = Mas.Where(i=>i<=3);
            foreach (var num in Mas1)
            {
                Console.WriteLine(num);
            }
        }
    }
}
