using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _002_ThreadStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(Number.PrintNumbers));
            Thread t2 = new Thread(delegate() { Number.PrintNumbers(); });
            Thread t3 = new Thread(() => Number.PrintNumbers());
            t1.Start();
            t2.Start();
            t3.Start();
        }
    }

    class Number
    {
        public static void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
