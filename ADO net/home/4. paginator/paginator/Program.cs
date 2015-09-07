using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paginator
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Student> res = Student.GetAll().Skip(3);

            int page = 1;
            int perPage = 3;

            ConsoleKeyInfo a;


            while (true)
            {
                a = Console.ReadKey();
                if (a.Key == ConsoleKey.RightArrow)
                {
                    Console.Clear();
                    var paging = Student.GetAll().Skip((page - 1) * perPage).Take(perPage);
                    page++;
                    foreach (var el in paging)
                    {
                        Console.WriteLine(el);
                    }
                }

                if (a.Key == ConsoleKey.LeftArrow)
                {
                    Console.Clear();
                    var paging = Student.GetAll().Skip(page-1).Take(perPage);  
                    page--;
                    foreach (var el in paging)
                    {
                        Console.WriteLine(el);
                    }
                }

            } // while (true)
            
        }
    }
}
