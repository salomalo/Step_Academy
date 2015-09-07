using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Entity_table_splitting
{
    class Program
    {
        static void Main(string[] args)
        {
            // using (var ctx = new EmployeeDbContext())
            // {
            //     ctx.Entry(new Employee()).State =
            //         System.Data.Entity.EntityState.Unchanged;
            //     ctx.SaveChanges();
            // }

            using (var ctx = new testEntities())
            {
                foreach (var e in ctx.Employees)
                {
                    Console.WriteLine(
                            e.Id
                            + " " +
                            e.Name
                            +" " +
                            e.Gender
                            + " " +
                            e.Jobtitle
                        );
                }

                Console.WriteLine("\n============================\n");

                foreach(var e in ctx.EmployeeDetails)
                {
                    Console.WriteLine(
                            e.Id
                            + " " +
                            e.Email
                            + " " +
                            e.Phone
                            + " " +
                            e.Salary
                        );
                }
            }
        }
    }
}
