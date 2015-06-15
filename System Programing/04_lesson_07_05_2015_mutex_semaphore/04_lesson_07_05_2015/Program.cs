using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_lesson_07_05_2015
{
    class Program
    {
        static object obj1 = new object();
        static object obj2 = new object();
        static object obj3 = new object();

        static void Main(string[] args)
        {
            //Thread tr1 = new Thread(Method1);
            //tr1.Start();  
            
            //Thread tr2 = new Thread(Method2);
            //tr2.Start();
           
            //Thread tr3 = new Thread(Method3);
            //tr3.Start();


            Thread tr5 = new Thread(Method5);
            tr5.Start();
        }




        public static void Method5()
        {
            Class1 cl = new Class1();

            lock (cl)
            {
                Thread.Sleep(100);
                lock (obj2)
                {
                    Console.WriteLine("......");
                }
            }
        }




        public static void Method1()
        {
            lock (obj1)
            {
                Thread.Sleep(100);
                lock (obj2)
                {
                    Console.WriteLine("hello......");
                }
            }
        }

        public static void Method2()
        {
            lock (obj2)
            {
                Thread.Sleep(100);
                lock (obj1)
                {
                    Console.WriteLine("......world");
                }
            }
        }


        public static void Method3()
        {
            lock (obj3)
            {
                Thread tmp = new Thread(Method3);
                tmp.Start();

                //Thread.Sleep(100);
                lock (obj3)
                {
                    Console.WriteLine("hello......world");
                }
            }
        }


    } // progr
}
