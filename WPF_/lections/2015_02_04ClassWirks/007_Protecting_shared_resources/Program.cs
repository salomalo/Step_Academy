using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace _007_Protecting_shared_resources
{
    class Program
    {
        static long _total = 0;

        static object _lock = new object();

        public static void AddOneMillion()
        {
            for (long i = 0; i < 10000000; i++)
            {
                //Interlocked.Increment(ref _total); // 1 way

                // lock (_lock)
                // {
                //     ++_total;
                // }

                Monitor.Enter(_lock);
                try
                {
                    ++_total;
                }
                finally
                {
                    Monitor.Exit(_lock);
                }

            }
        }

        static void Main(string[] args)
        {
            Stopwatch watch = Stopwatch.StartNew();
            
            // AddOneMillion();
            // AddOneMillion();
            // AddOneMillion();

            Thread t1 = new Thread(AddOneMillion);
            Thread t2 = new Thread(AddOneMillion);
            Thread t3 = new Thread(AddOneMillion);
            
            t1.Start();
            t2.Start();
            t3.Start();
            
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("_total = " + _total);
            watch.Stop();

            Console.WriteLine("Total time = " + watch.ElapsedMilliseconds + " ms");
        }
    }
}
