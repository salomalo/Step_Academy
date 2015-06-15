using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_lesson_06_06_2015
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Основной поток: ставим в очередь рабочий элемент");
            Random r = new Random();

            for (int i = 0; i < 10000; ++i)
                ThreadPool.QueueUserWorkItem(WorkingElementMethod, r.Next(10));         

            Console.WriteLine("Основной поток: выполняем другие задачи");
            Thread.Sleep(1000);
            
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadLine();
        }

        private static void WorkingElementMethod(object state)
        {
            Console.WriteLine("\tпоток: {0} состояние = {1}",
                Thread.CurrentThread.ManagedThreadId, state);
            Thread.Sleep(1000);
        }


    }
}
