using System;
using System.Threading;

namespace SafeThreadSingleTonButNotLazy
{
    public sealed class MySingleton
    {
        private static readonly MySingleton myInstance = null;

        static MySingleton()
        {
            myInstance = new MySingleton();
        }

        private MySingleton()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Got some instance");
        }

        public string GetData()
        {
            return Guid.NewGuid().ToString();
        }

        public static MySingleton Instance
        {
            get
            {
                return myInstance;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before call");
            for (int i = 0; i < 1000; i++)
            {
                var ins = MySingleton.Instance;
            }
            Console.WriteLine("After call");
        }
    }
}
