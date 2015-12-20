using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{
    class Program
    {

        private static Mutex m = new Mutex();

        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(Met));
            t.Start();
            m.ReleaseMutex();



        }

        public static void Met()
        { 
        
        }


    }
}