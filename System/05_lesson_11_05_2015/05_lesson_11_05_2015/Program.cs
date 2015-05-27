using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_lesson_11_05_2015
{
    class Program
    {
        static void Main(string[] args)
        {
           ManualEventTest();
           //AutoEventTest();
        }

        private static void AutoEventTest()
        {
            Console.WriteLine("\nСобытие с авто сбросом:");
            AutoResetEvent are = new AutoResetEvent(true);

            for (int i = 0; i < 10; ++i)
                ThreadPool.QueueUserWorkItem(SomeEventMethod, are);

            Console.ReadKey();
        }

        private static void ManualEventTest()
        {
            Console.WriteLine("Событие с ручным сбросом:");
            ManualResetEvent mre = new ManualResetEvent(true);

            for (int i = 0; i < 10; ++i)
                ThreadPool.QueueUserWorkItem(SomeEventMethod, mre);

            Console.ReadKey();
        }
        
        // сигнальний стан - він вільний - true

        static void SomeEventMethod(object obj)
        {
            EventWaitHandle ev = obj as EventWaitHandle;

            if (ev.WaitOne(10))
            {
                Console.WriteLine("Поток {0} успел проскочить", Thread.CurrentThread.ManagedThreadId);
                ev.Reset();
                // авто  ev.Reset(); не треба бо він зразу скидає
                // мануал - ev.Reset(); треба бо після 10 мілісек відбувається сктдання
            }
            else
                Console.WriteLine("Поток {0} опоздал", Thread.CurrentThread.ManagedThreadId);


        }



    }
}
