using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Semaphore s = new Semaphore(3, 3, "My_SEMAPHORE"); // скільки можна заняти з початку (доступне місце ) , максимум який може доступитися
          
            for (int i = 0; i < 6; ++i)
                ThreadPool.QueueUserWorkItem(SomeMethod, s);

            Console.ReadKey();
        }


        static void SomeMethod(object obj)
        {
            Semaphore s = obj as Semaphore;
            bool stop = false;

            while (!stop)
            {
                if (s.WaitOne(500))
                {
                    try
                    {
                        Console.WriteLine("Поток {0} блокировку получил", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(2000);
                    }
                    finally
                    {
                        stop = true;//коли завершиться пеший потік
                        s.Release();
                        Console.WriteLine("Поток {0} блокировку снял", Thread.CurrentThread.ManagedThreadId);
                    }
                }
                else
                    Console.WriteLine("Таймаут для потока {0} истек. Повторное ожидание", Thread.CurrentThread.ManagedThreadId);
            }
            
        }








    } // Program
}
