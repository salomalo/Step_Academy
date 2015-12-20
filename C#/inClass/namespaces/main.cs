using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ns_student;
using ns_group;

namespace ns_main
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] tmp = new int[2];

            for (int i = 0; i < 2; i++)
            {
                tmp[i] = r.Next(1, 12);
            }
            //stud.Print();
            //try
            //{
            //    Student stud = new Student("s@ome", "st.ud", "eee,e", 19, tmp);
            //    stud.Print();
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine("Error {0} ", e.Message);
            //}

            Student stud = new Student("some", "stud", "eeee", 18, tmp);
            Student stud2 = new Student("some2", "stud2", "eeee2", 20, tmp);

            Group group = new Group("1923P", 2013);
            group.AddStudent(stud);
            group.Print();
        }
    }
}