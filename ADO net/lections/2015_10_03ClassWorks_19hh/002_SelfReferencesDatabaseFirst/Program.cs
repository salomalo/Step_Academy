using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_SelfReferencesDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new testEntities())
            {
                var res = ctx.Employees.Select(emp => new { 
                    EmployeeName = emp.Name,
                    ManagerName = emp.Manager.Name == null ? "Super Boss" : emp.Manager.Name 
                });

                foreach (var e in res)
                {
                    Console.WriteLine(e.EmployeeName + " " + e.ManagerName);
                }
            }
        }
    }
}
