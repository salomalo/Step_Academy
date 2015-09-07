using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_crossJoin
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
                ,new Employee { Id = 5,  Name = "Mary",    DepartmentId = 2  }
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var res = 
                        from d in Department.GetAll()
                        from e in Employee.GetAll()
                        select new { e, d };

            foreach (var e in res)
            {
                Console.WriteLine(e.e.Name + "\t" + e.d.Name);
            }

        }
    }
}
