using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_ManyToMany_CodeFirst
{
    public class Course
    {
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public ICollection<Student> Students { set; get; }
    }
}
