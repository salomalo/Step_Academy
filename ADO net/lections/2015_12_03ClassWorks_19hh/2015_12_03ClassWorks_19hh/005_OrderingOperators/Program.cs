using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_OrderingOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrderedEnumerable<Student> res = Student.GetAll()
                .OrderBy(s => s.TotalMarks)
                .ThenBy(s => s.Name)
                .ThenByDescending(s => s.Id)
                ;

            res = from s in Student.GetAll()
                  orderby s.TotalMarks, s.Name, s.Id descending
                  select s;

            foreach (var s in res)
            {
                Console.WriteLine(s);
            }

            // 
            IEnumerable<Student> res2 = Student.GetAll();

            Console.WriteLine("Before: ");
            foreach (var s in res2)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\nAfter: ");
            IEnumerable<Student>  res3 = res2.Reverse();
            foreach (var s in res3)
            {
                Console.WriteLine(s);
            }



        }
    }
}
