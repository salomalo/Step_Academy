using System;
using System.Threading;

namespace InTime_HW3
{
    class Program
    {
        //события по таймеру c#

        public static void Method(object a)
        {
            string res;
            Console.WriteLine("\nsignal");
            res = Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Random r = new Random(10);
            r.Next(10, 100);

            TimerCallback callback = new TimerCallback(Method);

            Timer t = new Timer(callback);
            
            
            t.Change(0, 1000);
            Console.ReadLine();


            //Console.WriteLine("signal");
            //res = Console.ReadLine();
            //Console.WriteLine(res);




        }





    }
}
