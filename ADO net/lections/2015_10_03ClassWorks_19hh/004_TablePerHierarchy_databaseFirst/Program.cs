using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_TablePerHierarchy_databaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new testEntities())
            {
                var permanentEmployees = ctx.Employees.OfType<PermanentEmployee>();
                var contractEmployees = ctx.Employees.OfType<ContractEmployee>();

                Console.WriteLine("--== Table per Hierarchy ==--");

                Console.WriteLine("Permanent Employees:");
                foreach (var e in permanentEmployees)
                {
                    Console.WriteLine(
                            e.ID
                            + " " +
                            e.Name
                            + " " +
                            e.Gender
                            + " " +
                            e.AnnualSalary
                        );
                }

                Console.WriteLine("\nContract Employees:");
                foreach (var e in contractEmployees)
                {
                    Console.WriteLine(
                            e.ID
                            + " " +
                            e.Name
                            + " " +
                            e.Gender
                            + " " +
                            e.HourlyPay
                            + " " +
                            e.HoursWorked
                        );
                }

            }
        }
    }
}
