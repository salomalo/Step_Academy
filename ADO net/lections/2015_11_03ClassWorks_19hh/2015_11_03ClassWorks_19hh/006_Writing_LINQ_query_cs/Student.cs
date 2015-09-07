using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Writing_LINQ_query_cs
{
    public class Student
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }

        public static List<Student> GetAll()
        {
            List<Student> list = new List<Student>();

            Student std1 = new Student
            {
                Id = 101,
                Name = "mike",
                Gender = "male"
            };

            Student std2 = new Student
            {
                Id = 102,
                Name = "mari",
                Gender = "female"
            };

            Student std3 = new Student
            {
                Id = 103,
                Name = "john",
                Gender = "male"
            };

            Student std4 = new Student
            {
                Id = 104,
                Name = "todd",
                Gender = "male"
            };

            Student std5 = new Student
            {
                Id = 105,
                Name = "hope",
                Gender = "female"
            };

            list.Add(std1);
            list.Add(std2);
            list.Add(std3);
            list.Add(std4);
            list.Add(std5);

            return list;
        }

        public override string ToString()
        {
            return Id + ": " + Name + " " + Gender;
        }
 
    }
}
