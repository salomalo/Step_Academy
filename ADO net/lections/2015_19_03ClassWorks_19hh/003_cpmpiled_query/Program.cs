using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_cpmpiled_query
{
    class Program
    {
        static void Main(string[] args)
        {
            var compiledQuery = CompiledQuery.Compile((EmployeeDataContext ctx, int empId ) =>
                                                        (from e in ctx.Employees
                                                         where e.Id == empId
                                                         select e).Single());

            using (var ctx = new EmployeeDataContext())
            {
                int empId = 2;
                //Employee emp = (from e in ctx.Employees
                //               where e.Id == empId
                //               select e).Single();

                Employee emp = compiledQuery(ctx, empId);

                Console.WriteLine(
                            "   " +
                            emp.Id
                            + "\t" +
                            emp.Name
                            + "\t" +
                            emp.HourlyPay
                            + "\t" +
                            emp.HoursWorked
                            + "\t" +
                            emp.Discriminator
                        );
   
                
            }

        }
    }
}
