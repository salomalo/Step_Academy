using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_Writing_LINQ_query_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = Student.GetAll();

            Predicate<Student> stdPredicate = new Predicate<Student>(Find102Student);

            Console.WriteLine(list.Find(stdPredicate));

            Console.WriteLine(list.Find(delegate(Student s)
            {
                return s.Id == 103;
            }));

            Console.WriteLine(list.Find((Student s) => s.Id == 104));
            Console.WriteLine(list.Find(s => s.Id == 104));

            //
            int count = list.Count(s => s.Name.StartsWith("m"));
            Console.WriteLine("Count = {0}", count);

            Console.WriteLine("\n==================================\n");
            IEnumerable<Student> query = Student.GetAll().Where(s => s.Gender == "male");

            foreach (var s in query)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n==================================\n");
            query = from student in Student.GetAll()
                    where student.Gender == "female"
                    select student;

            foreach (var s in query)
            {
                Console.WriteLine(s);
            }



        }

        public static bool Find102Student(Student std)
        {
            return std.Id == 102;
        }
    }
}
