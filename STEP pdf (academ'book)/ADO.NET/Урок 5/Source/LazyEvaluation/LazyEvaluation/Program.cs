using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazyEvaluation
{
    // создадим класс с расширяющией функцией
    public static class Help
    {
        public static IEnumerable<T> LazyFilter<T>(
          this IEnumerable<T> enumerable,
          Predicate<T> predicate)
        {
            foreach (var e in enumerable)
                if (predicate(e))
                {
                    Console.Write("(true)");
                    yield return e;
                }
        }
    }
    class Program
    {
       static void Main(string[] args)
        {
         // создаем массив 
        IEnumerable<int> array = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //задаем фильтр
        var array1 = array.LazyFilter(n => n % 2 == 0);
        //выводим содержимое массива
        foreach (var elem in array1)
          Console.Write(elem + ", ");
             

        }
    }
}
