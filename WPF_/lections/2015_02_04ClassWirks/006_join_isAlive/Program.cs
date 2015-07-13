using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _006_join_isAlive
{
    class Program
    {
        public static void ThreadOneFunction()
        {
            Console.WriteLine("Thread One started");
            Thread.Sleep(5000);
            Console.WriteLine("Thread One is about to return");
        }

        public static void ThreadTwoFunction()
        {
            Console.WriteLine("Thread Two started");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main Started");

            Thread t1 = new Thread(ThreadOneFunction);
            t1.Start();

            Thread t2 = new Thread(ThreadTwoFunction);
            t2.Start();

            if (t1.Join(1000))
            {
                Console.WriteLine("Thread One Compleated");
            }
            else
            {
                Console.WriteLine("Thread One is not Compleated in 1 sec");
            }


            t2.Join();
            Console.WriteLine("Thread Two Compleated");

            for (int i = 0; i < 10; ++i)
            {
                if (t1.IsAlive)
                {
                    Console.WriteLine("Thread One is still working");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("Thread One Compleated");
                    break;
                }
            }


            Console.WriteLine("Main Compleated");

        }
    }
}
