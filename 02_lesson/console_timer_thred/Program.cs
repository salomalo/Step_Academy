using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace console_timer_thred
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadStart th = new ThreadStart(Method);
            //Thread _thread = new Thread(th);
            //_thread.Start();

            //while (true)
            //{
            //    Console.WriteLine(" main  ----    ");  
            //}

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(" main  ----    "+i);
            //}


        }


        static void Method()
        {
            while (true)
            {
                Console.WriteLine("---- Method      ");
            }

            //for(int i=0;i<100;i++)
            //{
            //        Console.WriteLine(i+" --- thread");
            //}

        }
    }
}
