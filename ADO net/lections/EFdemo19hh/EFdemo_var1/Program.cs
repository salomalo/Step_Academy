using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

namespace EFdemo_var1
{
    class Program
    {

        static void Main(string[] args)
        {
            // string cs = ConfigurationManager.ConnectionStrings["EFdemoEntities"].ConnectionString;
            // 
            // using (DbContext ctx = new DbContext(cs))
            // {
            //     ctx.Database.Log = Console.WriteLine;
            // 
            //     foreach (var item in ctx.Set<Employee>())
            //     {
            //         Console.WriteLine(item.Id
            //             + " " +
            //             item.Name
            //             + " " +
            //             item.Gender
            //             + " " +
            //             item.DepartmentId
            //             + " " +
            //             item.Salary
            //             );
            //     }
            // }

            using (var ctx = new EFdemoEntities())
            {
                var res = from e in ctx.Employees
                    select new {e.Id, e.Name, e.Salary};

                foreach (var item in res)
                {
                    Console.WriteLine(item.Id
                        + " " +
                        item.Name
                        + " " +
                        item.Salary
                        );
                }
            }

        }
    }
}
