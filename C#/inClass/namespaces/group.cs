using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ns_student;


namespace ns_group
{

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


        public void RemoveStudent(Student stud1) ///////////////////////////////////
        {
            Student[] studtmp = new Student[this.studlist.Length - 1];

            for (int i = 0; i < this.studlist.Length; i++)
            {
                if (this.studlist[i].Middlename != stud1.Middlename)
                {
                    studtmp[i] = this.studlist[i];
                }
            }

            Array.Resize(ref studlist, studlist.Length - 1);
            // this.studlist.Clone(
        }


        public void Print()
        {
            Console.WriteLine("Group: {0} {1}", Title, Year);

            //   for (int i = 0; i < studlist.Length; i++)
            //   {
            //        Console.WriteLine(this.studlist[i]);
            //   }
            //   Console.WriteLine(studlist.Length);

        }
    }
}