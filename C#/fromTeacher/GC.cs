using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GColector
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test(0);
            Console.WriteLine("Memory before: {0}", GC.GetTotalMemory(false));
            Thread.Sleep(2000);
            for (int i = 0; i < 1000; i++)
            {
                test.TestMethod(i + 1);
           
                Thread.Sleep(1000);
            }
         //   Thread.Sleep(2000);
            Console.WriteLine("Memory after: {0}", GC.GetTotalMemory(false));
        }
    }

    class Test : IDisposable
    {
        public int Count { set; get; }

        public Test(int count)
        {
            Count = count;
        }

        public void TestMethod(int count)
        {
            Test test = new Test(count);           
            Console.WriteLine("{0} object was created", test.Count);
            test.Dispose();
        }

        public void Dispose()
        {
            Console.WriteLine(this.Count + " killed");
        }

        ~Test()
        {
            Console.WriteLine(this.Count + " deleted");
        }

    }
}
