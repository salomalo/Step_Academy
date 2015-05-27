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
            //Class1 a = new Class1 ();

            ////a.B(100);

            //GC.Collect();
                        
            //a.Do();
                       
            //Console.ReadKey();


           // int t = 10000;
           // try
           // {
           //     for (int i = 0; i < 1000000000; i++)
           //     {
           //         a.B.Add(t);
           //     }
           // }
           // catch (Exception s)
           // {
           //     Console.WriteLine(s.Message);
           // }

           //Console.WriteLine(GC.CollectionCount(0).ToString());

      
            /////////////////////////////////////

            object obg = new object();
            Timer r = new Timer(new TimerCallback(Method),obg,500,500);
            Console.ReadLine();

        }  // main


        public static void Method(object a)
        {         
                Console.WriteLine("test test test");
                GC.Collect();             
        }





    } // program




}
