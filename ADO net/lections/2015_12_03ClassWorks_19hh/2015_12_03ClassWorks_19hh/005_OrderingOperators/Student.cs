using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_OrderingOperators
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; }

        public static List<Student> GetAll()
        {
            List<Student> listStudents = new List<Student>
            {
                new Student
                {
                    Id= 101,
                    Name = "mike",
                    TotalMarks = 800
                },
                new Student
                {
                    Id= 102,
                    Name = "marie",
                    TotalMarks = 900
                },
                new Student
                {
                    Id= 103,
                    Name = "hope",
                    TotalMarks = 800
                },
                new Student
                {
                    Id= 104,
                    Name = "john",
                    TotalMarks = 800
                },
                new Student
                {
                    Id= 105,
                    Name = "john",
                    TotalMarks = 800
                },
            };

            return listStudents;
        }

        public override string ToString()
        {
            return Id + ": " + Name + "\t" + TotalMarks;
        }

    }
}
