using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paginator
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }

        public static List<Student> GetAll()
        {
            List<Student> listStudents = new List<Student> { 
                new Student { Id = 101, Name = "Tom",   TotalMarks = 800 }, 
                new Student { Id = 102, Name = "Mary",  TotalMarks = 900 }, 
                new Student { Id = 103, Name = "Pam",   TotalMarks = 800 }, 
                new Student { Id = 104, Name = "John",  TotalMarks = 800 }, 
                new Student { Id = 105, Name = "John",  TotalMarks = 800 }, 
                new Student { Id = 106, Name = "Brian", TotalMarks = 700 }, 
                new Student { Id = 107, Name = "Todd",  TotalMarks = 750 }, 
                new Student { Id = 108, Name = "Ron",   TotalMarks = 850 }, 
                new Student { Id = 109, Name = "Rob",   TotalMarks = 950 }, 
                new Student { Id = 110, Name = "Alex",  TotalMarks = 750 }, 
                new Student { Id = 111, Name = "Susan", TotalMarks = 860 }, 
            };
            return listStudents;
        }
        public override string ToString()
        {
            return Id + ": " + Name + "\t" + TotalMarks;
        }
    }
}
