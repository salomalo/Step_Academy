using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_ManyToMany_CodeFirst
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Course> Courses { set; get; }
        public DbSet<Student> Students { set; get; } 
    }
}
