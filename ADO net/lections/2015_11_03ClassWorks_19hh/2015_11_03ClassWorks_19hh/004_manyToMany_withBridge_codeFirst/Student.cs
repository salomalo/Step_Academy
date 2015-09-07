using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_manyToMany_withBridge_codeFirst
{
    public class Student
    {
        public int StudentId { set; get; }
        public string StudentName { set; get; }
        public IList<StudentCourse> StudentCourses { set; get; }
    }
}
