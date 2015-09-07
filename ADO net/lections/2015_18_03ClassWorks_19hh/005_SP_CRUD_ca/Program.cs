using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_SP_CRUD_ca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  read");
            ShowEmployees();

            Console.WriteLine("  create");
            InsertEmployee(new Employee { 
                Name = "vasja",
                Gender = "male",
                Salary = 100500,
                DepartmentId = 1
            });

            ShowEmployees();

        }

        static List<Employee> GetAll()
        {
            using (EmployeeDataContext ctx = new EmployeeDataContext())
            {
                return ctx.Employees.ToList();
            }
        }

        static void ShowEmployees()
        {
            foreach (var e in GetAll())
            {
                Console.WriteLine(" " + e.Id + " " + e.Name + " " + e.Salary);
            }
            Console.WriteLine("____________________________________________");
        }

        static void InsertEmployee(Employee emp)
        {
            using (EmployeeDataContext ctx = new EmployeeDataContext())
            {
                // ctx.InsertEmployee(emp.Name, emp.Gender, emp.Salary, emp.DepartmentId);
                // ctx.DeleteEmployee(
                ctx.InsertEmployee(emp.Name, emp.Gender, emp.Salary, emp.DepartmentId);
                
                
                ctx.SubmitChanges();
            }
        }
    }
}
