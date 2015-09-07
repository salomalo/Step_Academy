using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_manyToMany_withBridge_databaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new testEntities())
            {
                var query = from student in ctx.Students
                            from studentCourse in student.StudentCourses
                            select new { 
                                StudentName = student.StudentName,
                                CourseName = studentCourse.Course.CourseName,
                                StartDate = studentCourse.StartDate
                            };

                foreach (var e in query)
                {
                    Console.WriteLine(
                            e.StudentName + "\t" +
                            e.CourseName + "\t" +
                            e.StartDate
                        );
                }

                // add mike to WPF
                StudentCourse mikeNewCourse = new StudentCourse { 
                    StudentID = 1,
                    CourseID = 4,
                    StartDate = DateTime.Now
                };

                ctx.StudentCourses.Add(mikeNewCourse);

                // remove john from SQL course
                StudentCourse johnRemoveCourse = 
                    ctx.StudentCourses.FirstOrDefault(s => s.StudentID == 2 && s.CourseID == 3);

                ctx.StudentCourses.Remove(johnRemoveCourse);
                ctx.SaveChanges();

                Console.WriteLine("\n++++++++++++++++++++++++++++++++\n");
                query = from student in ctx.Students
                        from studentCourse in student.StudentCourses
                        select new
                        {
                            StudentName = student.StudentName,
                            CourseName = studentCourse.Course.CourseName,
                            StartDate = studentCourse.StartDate
                        };

                foreach (var e in query)
                {
                    Console.WriteLine(
                            e.StudentName + "\t" +
                            e.CourseName + "\t" +
                            e.StartDate
                        );
                }
            }

        }
    }
}
