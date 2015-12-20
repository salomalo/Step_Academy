using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student();
            Student st2 = new Student("Name", "LastName", 20, new DateTime(1994, 12, 12), "SPR-20");
            Teacher tch = new Teacher("TeacherName", "TeacherLastName", 50, new DateTime(1964, 12, 12), "Design");
            Director dir = new Director("DirectorName", "DirectorLastName", 50, new DateTime(1964, 12, 12), "Design", true);
            Console.WriteLine();
         //   st2.Print();

            Person[] arr = new Person[] { st1, st2, tch , dir}; //boxing
            ((Student)arr[0]).Print();                          //unboxing

            if (arr[0] is Student)
            {
                Console.WriteLine((arr[0] as Student).Group);
            }
            else if (arr[0] is Director)
            {
                Console.WriteLine((arr[0] as Director).Subject);
            } 
            else if (arr[0] is Teacher)
            {
                Console.WriteLine((arr[0] as Teacher).Subject);
            }


            //foreach (Person person in arr)
            //{
            //    person.Print();
            //}

            foreach (Person person in arr)
            {
                try
                {

                    person.Work();
                }
                catch (CantWorkException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
         //   Person per = new Person();  // не можна створювати екземпляр абстрактного класу
            Person per = new Teacher();
            (per as Teacher).Print();
         
        }
    }

   public abstract class Person
    {
        public String Name { set; get; }
        public String LastName { set; get; }
        public int Age { set; get; }
        public DateTime Birthday { set; get; }

        public Person()
        {
            Console.WriteLine("Person()");
        }

        public Person(String name, String lastName, int age, DateTime birthday)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Birthday = birthday;
            Console.WriteLine("Person({0}, {1}, {2}, {3})", Name, LastName, Age, Birthday.ToShortDateString());
        }

        //public void Print()
        //{
        //    Console.WriteLine("Person: {0}, {1}, {2}, {3}", Name, LastName, Age, Birthday.ToShortDateString());
        //}

        public virtual void Print()
        {
            Console.WriteLine("Person: {0}, {1}, {2}, {3}", Name, LastName, Age, Birthday.ToShortDateString());
        }

        public abstract void Work();  //можуть бути лише в абстрактних класах
      

    }



    public  class Student : Person // НЕ МОЖЕ БУТИ БІЛЬШ ВІДКРИТИМ НІЖ БАТЬКІВСЬКИЙ КЛАС
    {
        public String Group { set; get; }
        public bool IsReasone { set; get; }
        public bool CanWork { set; get; }

        public Student()
        {
            Console.WriteLine("Student()");
        }

        public Student(String name, String lastName, int age, DateTime birthday, String group) : base(name, lastName, age, birthday)
        {
            Group = group;
            Console.WriteLine("Student({0}, {1}, {2}, {3}, {4})", Name, LastName, Age, Birthday.ToShortDateString(), Group);
        }

        //public new void Print()            //щоб явно скрити батьківський метод
        //{
        //    base.Print();
        //    Console.WriteLine("Group: {0}", Group);
        //}

        public override void Print()
        {
            base.Print();
            Console.WriteLine("Group: {0}", Group);
        }

        public override void Work()
        {

            if (!CanWork)
            {
                CantWorkException cwe = new CantWorkException("I cant work");
                cwe.IsReason = IsReasone;
                throw cwe;
            }
            else
            {
                Console.WriteLine("I am studing");
            }
         
        }
    }


    public class Teacher : Person 
    {
        public String Subject { set; get; }

        public Teacher()
        {
            Console.WriteLine("Teacher()");
        }

        public Teacher(String name, String lastName, int age, DateTime birthday, String subject)
            : base(name, lastName, age, birthday)
        {
            Subject = subject;
            Console.WriteLine("Teacher({0}, {1}, {2}, {3}, {4})", Name, LastName, Age, Birthday.ToShortDateString(), Subject);
        }

        public override void Print()            //щоб явно скрити батьківський метод
        {
            base.Print();
            Console.WriteLine("Subject: {0}", Subject);
        }

        public override void Work()
        {
            Console.WriteLine("I am teaching");
        }

      
    }

    public sealed class Director : Teacher  //заборона наслідування
    {
        public bool IsPower { set; get; }

        public Director()
        {
            Console.WriteLine("Teacher()");
        }

         public Director(String name, String lastName, int age, DateTime birthday, String subject, bool isPower)
            : base(name, lastName, age, birthday, subject)
        {
            IsPower = isPower;
            Console.WriteLine("Director({0}, {1}, {2}, {3}, {4})", Name, LastName, Age, Birthday.ToShortDateString(), Subject);
        }

         public override void Print()           
         {
             base.Print();
             Console.WriteLine("IsPower: {0}", IsPower);
         }

         public override void Work()
         {
             Console.WriteLine("I am managing");
         }

    }


 /*   public static class Test
    {

    }

    public static class TestTest : Test
    {

    }*/

    /* public class SuperDirector : Director  //не можем наслідуватися від sealed класу
     {

     }*/


    public class CantWorkException : ApplicationException
    {
        public CantWorkException() : base() { }

        public CantWorkException(String message) : base(message) { }

        public CantWorkException(String message, Exception InnerException) : base(message, InnerException) { }

        public CantWorkException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
            base(info, context) { }

        public bool IsReason { set; get; }
    }

    public class IsIllCantWorkException : CantWorkException
    {
        public IsIllCantWorkException() : base() { }

        public IsIllCantWorkException(String message) : base(message) { }

        public IsIllCantWorkException(String message, Exception InnerException) : base(message, InnerException) { }

        public IsIllCantWorkException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
            base(info, context) { }

        public String Illness { set; get; }

        public bool IsReason
        {
            get
            {
                return true;
            }
        }

    }
}
