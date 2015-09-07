using System;
using System.Linq.Expressions;

namespace ExpressionTree
{
    class Program
    {
        delegate bool del(int i);
        static void Main(string[] args)
        {
            // Обычная лямбда
            del isEven = n => (n % 2 == 0);
            Console.WriteLine(isEven); // ExpressionTree.Program+del

            // Expression 
            Expression<del> exIsEven = n => n % 2 == 0;
            Console.WriteLine(exIsEven); // n => ((n % 2) = 0)

            Console.WriteLine(isEven(2));   // true
           // Console.WriteLine(exIsEven(2)); // Compilation error

            // тело лямбды
            Console.WriteLine(exIsEven.Body); // ((n % 2)=0

            // имя параметра
            Console.WriteLine(exIsEven.Parameters[0]);
            //вычисляем выражение
            Console.WriteLine(exIsEven.Equals(5));


        }
    }
}
