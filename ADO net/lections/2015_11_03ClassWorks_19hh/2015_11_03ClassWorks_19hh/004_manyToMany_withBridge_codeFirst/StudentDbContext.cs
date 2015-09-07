using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_manyToMany_withBridge_codeFirst
{
    public class StudentDbContext : DbContext
    {

        public StudentDbContext() : base("CS") { }

        public DbSet<Course> Courses { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<StudentCourse> StudentCourses { set; get; }
    }
}
