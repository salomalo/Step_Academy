using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Single_table_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EmployeeDataContext())
            {

                Employee pEmp = new PermanentEmployee { 
                    Name = "ritchie",
                    Gender = "male",
                    AnuualSalary = 65000
                };

                Employee cEmp = new ContractEmployee
                {
                    Name = "Gonzalez",
                    Gender = "macho",
                    HourlyPay = 50 /*,*/
                    // HoursWorked = 80
                };

                ctx.Employees.InsertOnSubmit(pEmp);
                ctx.Employees.InsertOnSubmit(cEmp);
                ctx.SubmitChanges();

                // show
                Console.WriteLine("Permanent Employees:");

                foreach (var e in ctx.Employees.OfType<PermanentEmployee>())
                {
                    Console.WriteLine(
                            "   " +
                            e.Id
                            + "\t" +
                            e.Name
                            + "\t" +
                            e.AnuualSalary
                            +"\t" +
                            e.Discriminator
                        );
                }

                Console.WriteLine("Contract Employees:");

                foreach (var e in ctx.Employees.OfType<ContractEmployee>())
                {
                    Console.WriteLine(
                            "   " +
                            e.Id
                            + "\t" +
                            e.Name
                            + "\t" +
                            e.HourlyPay
                            + "\t" +
                            e.HoursWorked
                            + "\t" +
                            e.Discriminator
                        );
                }

                Console.WriteLine("All Employees:");

                foreach (var e in ctx.Employees)
                // foreach (var e in ctx.Employees.OfType<Employee>())
                {
                    Console.WriteLine(
                            "   " +
                            e.Id
                            + "\t" +
                            e.Name
                            + "\t" +
                            e.Discriminator
                        );
                }
            }
        }
    }
}
