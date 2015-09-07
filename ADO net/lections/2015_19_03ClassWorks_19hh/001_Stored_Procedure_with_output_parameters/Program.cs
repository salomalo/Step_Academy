using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo;
using System.Data.Linq;

namespace _001_Stored_Procedure_with_output_parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            // using (var ctx = new EmployeeDataContext())
            // {
            //     string deptName = string.Empty;
            //     var res = ctx.GetEmployeesByDepartment(1, ref deptName);
            // 
            //     Console.WriteLine("Department: " + deptName);
            //     foreach (var e in res)
            //     {
            //         Console.WriteLine("\t" + e.Id + " " + e.Name + " " + e.DepartmentId);
            //     }
            // 
            // }

            // string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
            // 
            // using (var ctx = new testDataContext(cs))
            // {
            //     foreach (var e in ctx.Employees)
            //     {
            //         Console.WriteLine("\t" + e.Id + " " + e.Name + " " + e.DepartmentId);
            //     }
            // }

            using (var ctx = new EmployeeDataContext())
            {
                ctx.Log = Console.Out;

                // 1
                // DataLoadOptions lo = new DataLoadOptions();
                // lo.LoadWith<Department>(d => d.Employees);
                // ctx.LoadOptions = lo;

                // 2 Projection
                var linQuery = from d in ctx.Departments
                               select new { Name = d.Name, Employees = d.Employees };

                foreach (var d in linQuery)
                // foreach (var d in ctx.Departments)
                {
                    Console.WriteLine(d.Name);

                    foreach (var e in d.Employees)
                    {
                        Console.WriteLine("\t" + e.Id + " " + e.Name + " " + e.DepartmentId);
                    }
                }
            }
        }
    }
}
