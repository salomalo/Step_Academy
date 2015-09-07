using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymusTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вот так выглядит объявление нового типа:
            var anon = new { age = 18, name = "vasa" };

            // дальше можно спокойно использовать
            Console.WriteLine("age = " + anon.age + "\tname = " + anon.name);

            // а так можно посмотреть, что же создалось:
            Console.WriteLine(anon.GetType());

        }
    }
}
