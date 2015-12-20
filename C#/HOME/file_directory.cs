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
            Console.WriteLine("enter path");
            String path = Console.ReadLine();


            DirectoryInfo dir = new DirectoryInfo(path);
            dir.GetDirectories();

            int count = 0;
            var res = dir.GetDirectories();
            long allsize=0;
            
            Console.WriteLine("{0}. {1,15}      {2,15}     {3}", "№", "title", "CreationTime", "LastWriteTime");
            var tmp=0;
            
            foreach (DirectoryInfo el in res)
            {
                count++;
                
                Console.WriteLine("{0}. {1,15}       {2,15}       {3}", count, el.Name, el.CreationTime, el.LastWriteTime);

               // tmp=el.GetFiles;
               //el.Name

            }


			
			          //  DirectoryInfo dir = new DirectoryInfo("D:\\");
         //   string pat = "fdg";
          //  dir.GetFiles(pat, SearchOption.AllDirectories)
			
			

            count = 0;
            Console.WriteLine("\n{0}. {1,10}      {2,10}     {3,15}  {4,4}  {5}", "№", "title", "CreationTime", "LastWriteTime", "extention", "size");
            var res2 = dir.GetFiles();
            foreach (FileInfo el in res2)
            {
                count++;
                Console.WriteLine("{0}. {1,10}       {2,10}      {3,15}  {4,4}  {5}", count, el.Name, el.CreationTime, el.LastWriteTime, el.Extension, el.Length);
            }

        }
    }
}