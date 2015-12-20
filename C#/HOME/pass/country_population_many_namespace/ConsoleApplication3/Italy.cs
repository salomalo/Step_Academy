using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Italy
{
    public class Rym
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

         public Rym(String title, int population) // constructor
        {
            this.population = population;
        }
    }
}