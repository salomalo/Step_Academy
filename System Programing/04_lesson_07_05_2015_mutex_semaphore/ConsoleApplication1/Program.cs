using System;
using System.Collections.Generic;
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
            Console.WriteLine("Синхронизация мютексом:");
            Counter c = new Counter();
         
            Mutex mtm = new Mutex(false, "SYNC_MUTEX");
            if (mtm.WaitOne(0))
            {
                Thread[] threads = new Thread[5];
                for (int i = 0; i < threads.Length; ++i)
                {
                    threads[i] = new Thread(c.UpdateFields);
                    threads[i].Start();
                }

                for (int i = 0; i < threads.Length; ++i)
                    threads[i].Join();

                Console.WriteLine("Count: {0}\n\n", c.Count);
                Console.ReadKey();
            }
            else 
            {
                Console.WriteLine("-----");
                Console.ReadKey();
            }

        //Mutex t;
        //    try
        //    {
        //        t = Mutex.OpenExisting("SYNC_MUTEX");
        //    }
        //    catch (Exception ex)
        //    {
        //       // Console.WriteLine(ex.Message);
        //        t = new Mutex(false,"SYNC_MUTEX");
        //    }

        //    Mutex tt;
        //    try
        //    {
        //        tt = Mutex.OpenExisting("SYNC_MUTEX");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

           // Mutex ttt =

        } // main
     
        class Counter
        {         
           int count;
           //Mutex mtm = new Mutex(false, "SYNC_MUTEX");

            public int Count
            {
                get { return count; }
            }

            public void UpdateFields()
            {
                for (int i = 0; i < 1000000; ++i)
                {
                    //m.WaitOne();
                    //++count;
                    //m.ReleaseMutex();

                    lock (this)
                    {
                        ++count;
                    }
                }
            }
        }
    }
}
