using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wonder_1;

namespace wonders
{

    public class Wonders
    {
        protected String name;


        public String Name
        {
            get { return name; }
            set { name = value;}
        }

        public void Print()
        {
            Console.WriteLine("Title: {0}", Name);

        }

        public void setName()
        {
            Wonder_1 a = new Wonder_1("i");
            this.name = a.Name;
        }


        public Wonders() // constructor
        {
          //  this.name = a.Name;
        }

    }
}
