using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace join
{
    class Program
    {

        static int ii=0;
        static int j=0;

        static void Main(string[] args)
        {

            ThreadStart ts = new ThreadStart(Method);
            Thread t = new Thread(ts);
            
            t.Start();
            
            t.Join();
          
           
            // t.IsBackground = true;

            
            for ( int i = 0; i < 10; i++)
            {
                ii++;
            }
            

            Console.WriteLine(j+ii);
        }


        static void Method()
        {
            for (int i = 0; i < 100000; i++)
            {
                j = i;
            }
        }

    }
}
