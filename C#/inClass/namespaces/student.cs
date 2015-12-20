using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ns_student
{

    public class Student
    {
        protected String name;
        protected String surname;
        protected String middlename;
        protected String group;
        protected int age;
        protected int[] prog;

        public int[] Prog
        {
            get { return prog; }
            set { prog = value; }
        }
        public String Name
        {
            get { return name; }
            set
            {
                if (value.IndexOfAny(new char[] { '@', '.', ',', '!' }) != -1)
                {
                    throw new ArgumentException("name contains spec symbols");
                }
                else
                    name = value;
            }
        }
        public String Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public String Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("age < 0");
                }
                else if (value > 150)
                {
                    throw new ArgumentException("age > 150");
                }
                else
                {
                    age = value;
                }
            }
        }
        public String Group
        {
            get { return group; }
            set { group = value; }
        }
        public void Print()
        {
            Console.WriteLine("Student: {0} {1} {2}", Name, Surname, Middlename);
            Console.WriteLine("Age: {0}", Age);
            Console.WriteLine("Group: {0}", Group);
            Console.WriteLine("prog ");
            for (int i = 0; i < prog.Length; i++)
            {
                Console.WriteLine(this.prog[i]);
            }
        }
        public Student(String nam, String surnam, String maddlenam, int ag, int[] arr) // constructor
        {
            this.name = nam;
            this.surname = surnam;
            this.middlename = maddlenam;
            this.Age = ag;
            this.prog = arr;
        }
    }
}
