using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_thread__prior
{
    class Program
    {
        static void Main(string[] args)
        {

            ThreadStart ts1 = new ThreadStart(Method1);
            ThreadStart ts2 = new ThreadStart(Method2);

            Thread t1 = new Thread(ts1);
            t1.Priority = ThreadPriority.Highest;

            Thread t2 = new Thread(ts2);
            t2.Priority = ThreadPriority.Lowest;

            t1.Start();
            t2.Start();

        }

        static  void  Method1()
        {
             while (true)
            {
                Console.WriteLine("1      ");
            }
        }

        static void Method2()
        {
            while (true)
            {
                Console.WriteLine("      2");
            }
        }

    }
}
