using System;
using System.Linq.Expressions;

namespace DinamicExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // создать параметр лямбды
            var parameterN = Expression.Parameter(typeof(int), "n");

            //  собственно построение выражения
            /* Предика - это функция, принимающая один параметр
             и возвращающая логическое выражение*/
            var expression = Expression.Lambda<Predicate<int>>(
              Expression.Equal( 
                Expression.Modulo(
                parameterN,
                Expression.Constant(2)),
                Expression.Constant(0)
              ),
              parameterN);

            // выводим, что получилось
            Console.WriteLine(expression); // n => ((n % 2) =0)

            // теперь это можно скомпилировать
            Predicate<int> compiledExpression = expression.Compile();

            // и использовать
            Console.WriteLine();
            Console.WriteLine(" 2 is Even ? " + compiledExpression(2)); // true
            Console.WriteLine(" 3 is Even ? " + compiledExpression(3)); // false

        }
    }
}
