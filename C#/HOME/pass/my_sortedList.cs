using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            myClass cl = new myClass();
            cl.Add(0.6);
            cl.Add(1.8);
            cl.Add(0.8);

            foreach (object el in cl)
            {
                Console.WriteLine(el);
            }
        }
    }

    public class myClass : IEnumerable
    {
        public ArrayList arr { set; get; }


        public IEnumerator GetEnumerator()
        {
            return arr.GetEnumerator();
        }
		
        public myClass()
        {
            arr = new ArrayList(0);
        }

        public void Add(double a)
        {
            arr.Add(a);
			arr.Sort();
        }

        public void Print()
        {
            foreach (object el in arr)
            {
                Console.WriteLine(el);
            }
        }


    }
}