using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_tableSplittingCodeFirst
{
    public class EmployeeDetails
    {
        public int Id { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public int Salary { set; get; }

        public Employee Employee { set; get; }
    }
}
