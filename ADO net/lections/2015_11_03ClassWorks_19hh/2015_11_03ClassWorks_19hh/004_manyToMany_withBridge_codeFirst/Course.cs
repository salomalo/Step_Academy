using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_manyToMany_withBridge_codeFirst
{
    public class Course
    {
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public IList<StudentCourse> StudentCourses { set; get; }
    }
}
