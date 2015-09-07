using System.Collections.Generic;

namespace _002_CodeFirstApproachDemo
{
    public class Department
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Location { set; get; }

        public List<Employee> Employees { set; get; }
    }
}
