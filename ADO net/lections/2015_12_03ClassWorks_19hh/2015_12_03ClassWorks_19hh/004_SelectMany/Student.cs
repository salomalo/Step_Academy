using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_SelectMany
{
    public class Student
    {
        //public int Id { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public List<string> Subjects { set; get; }

        public static List<Student> GetAll()
        {
            List<Student> listStudents = new List<Student>
            {            
                new Student
                {
                    Name = "mike",
                    Gender = "male",
                    Subjects = new List<string> { "ASP.NET", "C#" }
                },
                new Student
                {
                    Name = "todd",
                    Gender = "male",
                    Subjects = new List<string> { "ADO.NET", "C#", "AJAX" }
                },
                new Student
                {
                    Name = "hope",
                    Gender = "female",
                    Subjects = new List<string> { "WCF", "SQL Server", "C#" }
                },
                new Student
                {
                    Name = "marie",
                    Gender = "female",
                    Subjects = new List<string> { "WPF", "LINQ", "ASP.NET" }
                }
            };

            return listStudents;
        }

    }
}
