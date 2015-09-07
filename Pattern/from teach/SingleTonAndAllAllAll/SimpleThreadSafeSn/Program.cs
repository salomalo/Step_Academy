using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadSafeSn
{

    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlack = new object();

        Singleton()
        {
            Console.WriteLine("Simple thread save singleton");
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlack)
                {
                    if (instance == null)
                    {
                        Thread.Sleep(1000);

                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var threads = new Thread[1000];
            for (int i = 0; i < 1000; i++)
            {
                threads[i] = new Thread(() =>
                {
                    var dd = Singleton.Instance;
                    Console.WriteLine("Thread #{0}", i);

                });
                threads[i].Start();
            }
        }
    }
}
