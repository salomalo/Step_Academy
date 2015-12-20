using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace wonders
{

    public class Wonder_5
    {
        protected String name;

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

        public void Print()
        {
            Console.WriteLine("Title: {0}", Name);

        }

        public Wonder_5(String nam) // constructor
        {
            this.name = nam;
        }


    }
}
