using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Project_Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> res = Employee.GetAll().Select(e => e.Id);

            //var res2 = Employee.GetAll().Select(e => new { Name = e.Name, Gender = e.Gender });
            var res2 = Employee.GetAll().Select(e => new { e.Name, e.Gender });

            foreach (var e in res2)
            {
                Console.WriteLine(e.Name + "\t" + e.Gender);
            }
            Console.WriteLine("===============================");


            var res3 = Employee.GetAll().Select(e => new { e.Name, MonthlySalary = e.AnnualSalary / 12 });
            foreach (var e in res3)
            {
                Console.WriteLine(e.Name + "\t" + e.MonthlySalary);
            }
            Console.WriteLine("===============================");


            var res4 = Employee.GetAll()
                .Where(e => e.AnnualSalary > 50000)
                .Select(e => new { Name = e.Name, Salary = e.AnnualSalary, Bonus = e.AnnualSalary * 0.01 });

            foreach (var e in res4)
            {
                Console.WriteLine(e.Name + "\t" + e.Salary + "\t" + e.Bonus);
            }
            Console.WriteLine("===============================");
        }
    }
}
