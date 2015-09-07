using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_TablePerHierarchy_CodeFirst
{
    public abstract class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
    }
}
