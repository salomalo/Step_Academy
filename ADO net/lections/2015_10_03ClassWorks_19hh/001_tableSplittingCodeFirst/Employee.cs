using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_tableSplittingCodeFirst
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public string JobTitle { set; get; }

        public EmployeeDetails EmployeeDetails { set; get; }
    }
}
