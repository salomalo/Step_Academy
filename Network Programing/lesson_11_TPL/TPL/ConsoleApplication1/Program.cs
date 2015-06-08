using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colors = {
                                  "Red",
                                  "Green",
                                  "Yellow",
                                  "Blue",
                                  "White",
                                  "Black",
                                  "Orange"
                              };

            var watch = Stopwatch.StartNew();
            foreach(var c in colors)
            {
                Console.WriteLine("ThreadId: {0} with color: {1}", Thread.CurrentThread.ManagedThreadId, c);
                Thread.Sleep(10);
            }
            Console.WriteLine("Simple foreach: {0}", watch.ElapsedMilliseconds);

            watch = Stopwatch.StartNew();
            Parallel.ForEach(colors, c =>
            {
                {
                    Console.WriteLine("ThreadId: {0} with color: {1}", Thread.CurrentThread.ManagedThreadId, c);
                    Thread.Sleep(10);
                }
            });
            Console.WriteLine("Parallel.foreach: {0}", watch.ElapsedMilliseconds);


        }
    }
}
