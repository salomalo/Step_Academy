using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_parametr_thread
{
    class Program
    {
        static void Main(string[] args)
        {

            ParameterizedThreadStart pts = new ParameterizedThreadStart(Method);
            Thread t = new Thread(pts);
            t.Start((object)"2");


        }


        static void Method(object str)
        {

            string s = (string)str;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("{0} --- {1}",i.ToString(),s);
            }
        
        }


    }
}
