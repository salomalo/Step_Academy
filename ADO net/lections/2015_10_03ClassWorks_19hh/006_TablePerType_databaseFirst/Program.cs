using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_TablePerType_databaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new testEntities())
            {
                foreach (var e in ctx.Employees.OfType<PermanentEmployee>())
                {
                    Console.WriteLine(
                            e.Id
                            + " " +
                            e.Name
                            + " " +
                            e.Gender
                            + " " +
                            e.AnnualSalary
                        );
                }

                Console.WriteLine("=========================");

                foreach (var e in ctx.Employees.OfType<ContractEmployee>())
                {
                    Console.WriteLine(
                            e.Id
                            + " " +
                            e.Name
                            + " " +
                            e.Gender
                            + " " +
                            e.HoursWorked
                            + " " +
                            e.HourlyPay
                        );
                }

                Console.WriteLine("=========================");
                
            }
        }
    }
}
