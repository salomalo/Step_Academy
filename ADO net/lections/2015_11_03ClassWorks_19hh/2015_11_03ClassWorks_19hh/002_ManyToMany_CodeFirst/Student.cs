using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_ManyToMany_CodeFirst
{
    public class Student
    {
        public int StudentId { set; get; }
        public string StudentName { set; get; }
        public ICollection<Course> Courses { set; get; }
    }
}
