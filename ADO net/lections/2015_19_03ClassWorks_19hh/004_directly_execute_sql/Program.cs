using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_directly_execute_sql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EmployeeDataContext())
            {
                // IEnumerable<Employee> res = 
                //     ctx.ExecuteQuery<Employee>("select * from Employees where Gender = 'male'");
                // 
                // IEnumerable<Employee> res2 =
                //     ctx.ExecuteQuery<Employee>("select * from Employees where Gender = {0}", "macho");
                // 
                // foreach (var e in res2)
                // {
                //     Console.WriteLine(e.Id + " " + e.Name + " " + e.Discriminator);
                // }

                // // Update
                // int count = ctx.ExecuteCommand("update Employees set Name = {0} where Id = {1}", "Bill Gates", 1);

                
                                
                // identity cache
                // Example 1

                // ctx.Log = Console.Out;
                // 
                // Employee emp1 = ctx.Employees.FirstOrDefault(x => x.Id == 1);
                // Employee emp2 = ctx.Employees.FirstOrDefault(x => x.Id == 1);
                // 
                // Console.WriteLine("emp1 == emp2 : {0}", object.ReferenceEquals(emp1, emp2));

            }

            // // Example 2
            // 
            // using (var ctx1 = new EmployeeDataContext())
            // {
            //     using (var ctx2 = new EmployeeDataContext())
            //     {
            //         ctx1.Log = Console.Out;
            //         ctx2.Log = Console.Out;
            // 
            //         Employee emp1 = ctx1.Employees.FirstOrDefault(x => x.Id == 1);
            //         Employee emp2 = ctx2.Employees.FirstOrDefault(x => x.Id == 1);
            // 
            //         Console.WriteLine("emp1 == emp2 : {0}", object.ReferenceEquals(emp1, emp2));
            //     }
            // 
            // }

            
            // Example 3

            using (var ctx1 = new EmployeeDataContext())
            {
                using (var ctx2 = new EmployeeDataContext())
                {
                    ctx1.Log = Console.Out;
                    ctx2.Log = Console.Out;

                    Employee emp1 = ctx1.Employees.FirstOrDefault(x => x.Id == 1);
                    Employee emp2 = ctx2.Employees.FirstOrDefault(x => x.Id == 1);

                    Console.WriteLine("emp1 == emp2 : {0}", object.ReferenceEquals(emp1, emp2));

                    Console.WriteLine("emp1.Name: " + emp1.Name);
                    Console.WriteLine("emp2.Name: " + emp2.Name);

                    emp1.Name = "GONZALEZ#";
                    ctx1.SubmitChanges();

                    emp1 = ctx1.Employees.FirstOrDefault(x => x.Id == 1);
                    emp2 = ctx2.Employees.FirstOrDefault(x => x.Id == 1);

                    Console.WriteLine("\n-------------------------------------------\nemp1.Name: " + emp1.Name);
                    Console.WriteLine("emp2.Name: " + emp2.Name);

                    ctx2.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, emp2);

                    Console.WriteLine("\n-------------------------------------------\nemp1.Name: " + emp1.Name);
                    Console.WriteLine("emp2.Name: " + emp2.Name);
                }

            }
        }
    }
}
