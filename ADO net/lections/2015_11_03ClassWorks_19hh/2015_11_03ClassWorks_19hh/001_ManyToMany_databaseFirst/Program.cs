using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_ManyToMany_databaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new testEntities())
            {
                var res = from student in ctx.Students
                          from course in student.Courses
                          select new
                          {
                              StudentName = student.StudentName,
                              CourseName = course.CourseName
                          };

                foreach (var i in res)
                {
                    Console.WriteLine(i.StudentName + "\t" + i.CourseName);
                }

                res = from course in ctx.Courses
                          from student in course.Students
                          select new
                          {
                              StudentName = student.StudentName,
                              CourseName = course.CourseName
                          };
                Console.WriteLine("\n==============================\n");
                foreach (var i in res)
                {
                    Console.WriteLine(i.StudentName + "\t" + i.CourseName);
                }

            }

        }
    }
}
