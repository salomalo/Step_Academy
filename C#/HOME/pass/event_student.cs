using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_class
{
 public delegate void DelEv(object sender, EventArgs args); //   delegate    /////////////////////////////////////////

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



            Student stud = new Student("petro", "petrov", "petrovich", 18);
            Student stud2 = new Student("makar", "makarov", "makarovich", 20);
            stud2.AddMax(10);
            stud2.AddMax(11);
            stud2.AddMax(12);


            Group group = new Group("19-23-P", 2013);
            group.AddStudent(stud);
            group.AddStudent(stud2);


            Student stud3 = new Student("misha", "mihaylovich", "miha", 18);
            Student stud4 = new Student("sergey", "serg", "serg", 20);

            Group group2 = new Group("8-23-P", 2013);
            group2.AddStudent(stud3);
            group2.AddStudent(stud4);

            Teacher teach = new Teacher("ivan", "ivanov", "ivanovich", 27, "programmer");
            teach.AddGroup(group);
            teach.AddGroup(group2);
            //teach.Print();

            teach.SetMark(1334, "makarov");
           // teach.Print();

           


        }

        public class Student
        {
            public event DelEv MarkIsAdd; ///// creat an event

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

            public void AddMax(int max)
            {
                Array.Resize(ref prog, prog.Length + 1);
                prog[prog.Length - 1] = max;
                OnEvent();
            }

            public void OnEvent()
            {
                if (MarkIsAdd != null)
                {
                    MarkIsAdd(this, EventArgs.Empty);
                }
            
            }

            public void  PrintInfo(object sender, EventArgs args)
            {
                Print();
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
              //  Console.WriteLine("Age: {0}", Age);
              //  Console.WriteLine("Group: {0}", Group);
                Console.WriteLine("prog ");
                for (int i = 0; i < prog.Length; i++)
                {
                    Console.WriteLine("{0}", this.prog[i]);
                }
                Console.WriteLine(" ");
            }
            public Student(String nam, String surnam, String maddlenam, int ag) // constructor
            {
                this.prog = new int[0];
                this.name = nam;
                this.surname = surnam;
                this.middlename = maddlenam;
                this.Age = ag;
                MarkIsAdd += PrintInfo;

            }
        }

        public class Group
        {
            protected String title;
            protected int year;
            protected Student[] studlist;

            public String Title
            {
                get { return title; }
                set { title = value; }
            }
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            public Student[] Studlist
            {
                get { return studlist; }
                //   set { studlist = value;}
            }
            public Group(String titl, int yea) // constructor
            {
                studlist = new Student[0];
                this.title = titl;
                this.year = yea;
            }
            public void AddStudent(Student stud1)
            {
                Array.Resize(ref studlist, studlist.Length + 1);
                stud1.Group = Title;
                studlist[studlist.Length - 1] = stud1;
            }
            public Student this[int index]
            {
                set
                {
                    if (index > studlist.Length - 1 || index < 0)
                    {
                        throw new IndexOutOfRangeException("to short");
                    }
                    studlist[index] = value;
                }
                get
                {
                    if (index > studlist.Length - 1 || index > 0)
                    {
                        throw new IndexOutOfRangeException("to long");
                    }
                    return studlist[index];
                }
            }
            public void RemoveStudent(Student stud1) ///////////////////////////////////
            {
                Student[] studtmp = new Student[this.studlist.Length - 1];
                for (int i = 0, k = 0; i < studtmp.Length; i++)
                {
                    if (this.studlist[i].Middlename != stud1.Middlename)
                    {
                        studtmp[i] = this.studlist[k];
                        k++;
                    }
                }
                studlist = studtmp;
            }
            public void Print()
            {
                int count = 0;
                Console.WriteLine("Group: {0} {1}", Title, Year);
                for (int i = 0; i < studlist.Length; i++)
                {
                    count++;
                    Console.Write(count + ". ");
                    this.studlist[i].Print(); // because 
                }
                // Console.WriteLine(studlist.Length);
            }

        }


        public class Teacher
        {
            protected String name;
            protected String surname;
            protected String middlename;
            protected String subject;
            protected Group[] grouplist;
            protected int age;

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
            public String Subject
            {
                get { return subject; }
                set { subject = value; }
            }

            public Group[] Grouplist
            {
                get { return grouplist; }
                set { grouplist = value; }
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

            public void AddGroup(Group group)
            {
                Array.Resize(ref grouplist, grouplist.Length + 1);
                grouplist[grouplist.Length - 1] = group;
            }

            public void SetMark(int max, String surname)
            {

                for (int i = 0; i < grouplist.Length; i++)
                {
                    for (int j = 0; j < grouplist[i].Studlist.Length; j++)
                    {
                        if (grouplist[i].Studlist[j].Surname == surname)
                        {
                            grouplist[i].Studlist[j].AddMax(max);
                        }
                    }

                }

                


            }

            public void Print()
            {
                int count = 0;
                Console.WriteLine("Teacher: {0} {1} {2}", Name, Surname, Middlename);
                Console.WriteLine("Age: {0}", Age);
                Console.WriteLine("Subject: {0}", Subject);
                for (int i = 0; i < grouplist.Length; i++)
                {
                    count++;
                    Console.Write(count + ". ");
                    this.grouplist[i].Print(); // because 
                }

            }

            public Teacher(String nam, String surnam, String maddlenam, int ag, String subject) // constructor
            {
                this.name = nam;
                this.surname = surnam;
                this.middlename = maddlenam;
                this.subject = subject;
                grouplist = new Group[0];
                this.Age = ag;
            }







        }


    }
}