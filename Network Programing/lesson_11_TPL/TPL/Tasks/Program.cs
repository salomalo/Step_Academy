using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 0; i < 10; i++)
            //{
            //    Task task = new Task(() =>
            //    {
            //        Console.WriteLine("Hello, ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            //        Thread.Sleep(100);

            //    });
            //    task.Start();
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Task task = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Hello factory, ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            //        Thread.Sleep(100);
            //    });
            //}

            //Console.Read();


            //Task[] tasks = new Task[10];
            //for (int i = 0; i < 10; i++)
            //{
            //    tasks[i] = new Task(() =>
            //    {
            //        Console.WriteLine("Hello, ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            //        Thread.Sleep(100);

            //    });
            //    tasks[i].Start();
            //}

            //Task.WaitAll(tasks, 100);

            Task<int> task = new Task<int>(() => Convert.ToInt32(Console.ReadLine()));

            task.Start();
            var res = task.Result;

            Console.WriteLine("Result: {0}", res);

            Console.WriteLine("The end!");

            //for (int i = 0; i < 10; i++)
            //{
            //    Task task = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("Hello factory, ThreadId: {0}", Thread.CurrentThread.ManagedThreadId);
            //        Thread.Sleep(100);
            //    });
            //}

            Console.Read();
        }
    }
}
