using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_SelectMany
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            string[] strArr = { 
                                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                                "0123456789"
                              };

            IEnumerable<string> res = strArr.Select(s => s);

            foreach (var s in res)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            //////////// 2.
            IEnumerable<string> subjects = Student.GetAll()
                .SelectMany(s => s.Subjects).Distinct();

            subjects = (from student in Student.GetAll()
                       from subject in student.Subjects
                       select subject).Distinct();


            foreach (var s in subjects)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("========================================");

            var res2 = Student.GetAll().SelectMany(s => s.Subjects, 
                (student, subject) => new { 
                    StudentName = student.Name, 
                    SubjectName = subject});

            res2 = from student in Student.GetAll()
                   from subject in student.Subjects
                   select new { StudentName = student.Name, SubjectName = subject }; 

            foreach (var s in res2)
            {
                Console.WriteLine(s.StudentName + "\t" + s.SubjectName);
            }
            Console.WriteLine("========================================");



            IEnumerable<List<string>> resSelect = Student.GetAll().Select(s => s.Subjects);

            foreach (List<string> list in resSelect)
            {
                foreach (string str in list)
                {
                    Console.WriteLine(str);
                }
            }

            Console.WriteLine("========================================");

            IEnumerable<string> resSelectMany = Student.GetAll().SelectMany(s => s.Subjects);
            foreach (string str in resSelectMany)
            {
                Console.WriteLine(str);
            }

        }
    }
}
