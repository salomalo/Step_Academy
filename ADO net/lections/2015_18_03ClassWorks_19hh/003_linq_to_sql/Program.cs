using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_linq_to_sql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EmployeeDataContext())
            {
                // 1
                // ctx.Log = Console.Out;

                // 2
                // var linqQuery = from e in ctx.Employees
                //              select e;

                var res = from e in ctx.Employees
                          join d in ctx.Departments
                          on e.DepartmentId equals d.Id
                          select new { 
                            Id = e.Id,
                            Name = e.Name,
                            Salary = e.Salary,
                            DeptName = d.Name
                          };
                
                // Console.WriteLine("res : " + res.ToString());

                // 3
                Console.WriteLine("Get Command: " + ctx.GetCommand(res).CommandText);

                // create
                Employee emp = new Employee { Name = "Bill Gates", Gender = "male", Salary = 4000, DepartmentId = 1 };
                ctx.Employees.InsertOnSubmit(emp);
                ctx.SubmitChanges();

                // update
                // Employee emp = ctx.Employees.FirstOrDefault(x => x.Id == 8);
                // emp.Salary = 4001;
                // ctx.SubmitChanges();

                // delete
                // Employee emp = ctx.Employees.FirstOrDefault(x => x.Id == 8);
                // ctx.Employees.DeleteOnSubmit(emp);
                // ctx.SubmitChanges();

                // read
                foreach (var e in res)
                {
                    Console.WriteLine(
                        e.Id
                        + " " +
                        e.Name
                        + " " +
                        e.Salary
                        + " " +
                        e.DeptName
                        );
                }

                Console.WriteLine("---------------------------");

                foreach (var e in ctx.GetEmployees())
                //foreach (var e in ctx.Employees)
                {
                    Console.WriteLine(e.Id
                        + " " +
                        e.Name
                        + " " +
                        e.Salary
                        + " " +
                        e.Gender
                        + " " +
                        e.DepartmentId
                        );
                }
            }

        }
    }
}
