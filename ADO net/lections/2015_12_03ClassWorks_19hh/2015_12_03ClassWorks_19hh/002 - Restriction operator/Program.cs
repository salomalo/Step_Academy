using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002___Restriction_operator
{
    class Program
    {
        private static bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // 1
            IEnumerable<int> evenNums = numbers.Where(x => x % 2 == 0);

            // 2
            Func<int, bool> func = x => x % 2 == 0;
            evenNums = numbers.Where(func);

            // 3
            evenNums = numbers.Where(n => IsEven(n));
            //evenNums = numbers.Where(IsEven);

            // 4 sql-like
            evenNums = from n in numbers
                       where n % 2 == 0
                       select n;

            // foreach (var n in evenNums)
            // {
            //     Console.WriteLine(n);
            // }

            // 5
            var res = numbers.Select((n, i) => new { Number = n, Index = i })
                .Where(x => x.Number % 2 != 0)
                ;

            foreach (var n in res)
            {
                Console.WriteLine(n.Index + ": " + n.Number);
            }

            Console.WriteLine("==========================================");
            var ctx = new testEntities();

            IEnumerable<Department> depts = ctx.Departments.Where(x => x.Name == "IT" || x.Name == "HR");

            foreach (var d in depts)
            {
                Console.WriteLine("Department: " + d.Name);

                IEnumerable<Employee> emps = d.Employees.Where(x => x.Gender == "male");

                foreach (var e in emps)
                {
                    Console.WriteLine("\t" + e.Name + "\t" + e.Gender);
                }
            }

        }
    }
}
