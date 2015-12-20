using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;


namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("enter filename");
            //  String filename = Console.ReadLine();

            Console.WriteLine("enter size");
            string Ssize = Console.ReadLine();

            int Isize;
            Int32.TryParse(Ssize, out Isize);

            string Sdate = Console.ReadLine();
            //  DateTime date=

            DirectoryInfo dir = new DirectoryInfo(@"D:/");
            dir.GetDirectories();
            int count = 0;
            //var res = dir.GetDirectories();
            //foreach (DirectoryInfo el in res)
            //{
            //    count++;
            //    if (el.Name == filename)
            //    {
            //        Console.WriteLine("{0}. {1,30}", count, el.Name);
            //    }
            //}

            var res2 = dir.GetFiles();
            foreach (FileInfo el in res2)
            {
                count++;
                //  if (el.Name.Contains(filename))
                //   {
                //       Console.WriteLine("{0}. {1,30}", count, el.Name);
                //   }
                //  if (el.Length == Isize) // в байтах - 1   10
                //   {
                //       Console.WriteLine("{0}. {1,30} {2,10}", count, el.Name, el.Length);
                //   }


                //  if (el.CreationTime.Date == date)
                //  {

                Console.WriteLine("{0}. {1,30} {2,10}", count, el.Name, el.CreationTime.Date);
                //    }

            }

        }


        public static void Find()
        {
        
        
        }
        


    }
}