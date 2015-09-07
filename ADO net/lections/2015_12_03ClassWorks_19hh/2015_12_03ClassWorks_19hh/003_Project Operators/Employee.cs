using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Project_Operators
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public int AnnualSalary { set; get; }

        public static List<Employee> GetAll()
        {
            List<Employee> res = new List<Employee>();

            Employee emp1 = new Employee
            {
                Id = 101,
                Name = "mike",
                Gender = "male",
                AnnualSalary = 60000
            };

            Employee emp2 = new Employee
            {
                Id = 102,
                Name = "mari",
                Gender = "female",
                AnnualSalary = 48000
            };

            Employee emp3 = new Employee
            {
                Id = 103,
                Name = "john",
                Gender = "male",
                AnnualSalary = 84000
            };

            Employee emp4 = new Employee
            {
                Id = 104,
                Name = "todd",
                Gender = "male",
                AnnualSalary = 64000
            };

            Employee emp5 = new Employee
            {
                Id = 105,
                Name = "hope",
                Gender = "female",
                AnnualSalary = 72000
            };

            res.Add(emp1);
            res.Add(emp2);
            res.Add(emp3);
            res.Add(emp4);
            res.Add(emp5);

            return res;
        }

        public override string ToString()
        {
            return Id + ": " + Name + "	" +
                Gender + "	" + AnnualSalary;
        }
    }
}
