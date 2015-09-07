using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SingleTonAndAllAllAll;

namespace SingleTonAndAllAllAll
{
    

    public sealed class MySingleton
    {
        public static int count = 0;

        private static MySingleton myInstance = null;

        MySingleton()
        {
            Console.WriteLine("Instance created!");
        }

        public string GetData()
        {
            return Guid.NewGuid().ToString();
        }

        public static MySingleton Instance
        {
            get
            {
                count++;
                if (myInstance == null)
                {
                    Thread.Sleep(1000);
                    myInstance = new MySingleton();
                }
                return myInstance;
            }
        }
    }


    internal class Program
    {
        private static void Main(string[] args)
        {
            var instance = MySingleton.Instance;
            var threads = new Thread[1000];
            for(int i =0; i < 1000; i++)
            {
                threads[i] = new Thread(() =>
                {
                     var dd =  MySingleton.Instance;
                    dd.GetData();
                });
            }

            for (int i = 0; i < 1000; i++)
            {
                threads[i].Start();
            }


            while (true)
            {
              var dd = MySingleton.Instance;
              dd.GetData();
            }

            //var tasks = new Task[100];

            //for (int i =0; i< tasks.Count(); i++)
            //{
            //    tasks[i] = Task.Run(() =>
            //    {
            //        var dd = MySingleton.Instance;
            //    });
            //}

            Console.Read();
        }
    }
}
