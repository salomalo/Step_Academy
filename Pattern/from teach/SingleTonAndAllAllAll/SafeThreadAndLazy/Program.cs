using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeThreadAndLazy
{
    public sealed class MySingleton
    {
        private static Lazy<MySingleton> _myInstance = new Lazy<MySingleton>(() => { return GetSinglTonInstance(); });

        private static MySingleton GetSinglTonInstance()
        {
         return new MySingleton();   
        }

        MySingleton()
        {
            Console.WriteLine("Instance created!");
        }

        public string GetData()
        {
            return Guid.NewGuid().ToString();
        }

        public static void SomeCoolMethod()
        {
            //DOING NOTHING
        }

        public static MySingleton Instance
        {
            get
            {

                return _myInstance.Value;
                int a = 0;

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MySingleton.SomeCoolMethod();
            var i = MySingleton.Instance;
            int a = 0;
        }
    }
}
