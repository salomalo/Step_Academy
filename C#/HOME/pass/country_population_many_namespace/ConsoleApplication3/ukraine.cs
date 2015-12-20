using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Ukraine
{
    public class Kyiv
    {
       protected int population;
       protected String title;

       public int Population
        {
            get { return population; }
            set { population = value; }
        }

       public String Title
       {
           get { return title; }
           set { title = value; }
       }

       public Kyiv(String title, int population) // constructor
        {
            this.population = population;
        }

        //public void Print()
        //{
        //    Console.WriteLine("Group: {0} {1}", Title);

        //    //   for (int i = 0; i < studlist.Length; i++)
        //    //   {
        //    //        Console.WriteLine(this.studlist[i]);
        //    //   }
        //    //   Console.WriteLine(studlist.Length);
        //}
    }
}