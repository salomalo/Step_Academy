using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _024_LeftOuterJoin
{
    class Program
    {
        public class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public static List<Department> GetAll()
            {
                return new List<Department>()
            {
                 new Department { Id = 1, Name = "IT"}
                ,new Department { Id = 2, Name = "HR"}
                ,new Department { Id = 3, Name = "XX"}
            };
            }
        }

        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int DepartmentId { get; set; }

            public static List<Employee> GetAll()
            {
                return new List<Employee>()
            {
                 new Employee { Id = 1,  Name = "Mike",      DepartmentId = 1 }
                ,new Employee { Id = 2,  Name = "Todd",      DepartmentId = 2 }
                ,new Employee { Id = 3,  Name = "Ben",       DepartmentId = 1 }
                ,new Employee { Id = 4,  Name = "Philip",    DepartmentId = 1 }
                ,new Employee { Id = 5,  Name = "Mary" }
                // ,new Employee { Id = 6,  Name = "Valarie",   DepartmentId = 2 }
                // ,new Employee { Id = 7,  Name = "John",      DepartmentId = 1 }
                // ,new Employee { Id = 8,  Name = "Pam",       DepartmentId = 1 }
                // ,new Employee { Id = 9,  Name = "Stacey",    DepartmentId = 2 }
                // //,new Employee { Id = 10, Name = "Andy",      DepartmentId = 1 }
                // ,new Employee { Id = 10, Name = "Andy" }
            };
            }
        }


        static void Main(string[] args)
        {
            // var res = from e in Employee.GetAll()
            //           join d in Department.GetAll()
            //           on e.DepartmentId equals d.Id into eGroup
            //           from d in eGroup.DefaultIfEmpty()
            //           select new { 
            //             EmployeeName = e.Name,
            //             DepartmentName = d == null ? "No department" : d.Name
            //           };

            var res = Employee.GetAll()
                .GroupJoin(Department.GetAll(),
                e => e.DepartmentId,
                d => d.Id,
                (e, d) => new
                {
                    e,
                    d
                })
                
                .SelectMany(x => x.d.DefaultIfEmpty(),
                (a, b) => new { 
                    EmployeeName = a.e.Name,
                    DepartmentName = b == null ? "No department" : b.Name
                })
                ;

            foreach (var e in res)
            {
                Console.WriteLine(e.EmployeeName + "\t" + e.DepartmentName);
            }

        }
    }
}
