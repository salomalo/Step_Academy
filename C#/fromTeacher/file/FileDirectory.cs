using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
           // File, FileInfo, Directory, DirectoryInfo
            if(File.Exists(@"D:/hello.cs") )
            {
                FileInfo fi = new FileInfo(@"D:/hello.cs");
                Console.WriteLine(fi.Attributes);
                fi.Attributes = FileAttributes.Device;
                Console.WriteLine(fi.Attributes);
              
                string txt = File.ReadAllText(@"D:/hello.cs");
                Console.WriteLine(txt);
            }

            DirectoryInfo dir = new DirectoryInfo(@"D:/");
            dir.GetDirectories();
            dir.CreateSubdirectory("ttt");
            var res = dir.GetFiles();

            foreach (FileInfo el in res)
            {
                Console.WriteLine(el.Name);
            }
            
            
        }
    }
}
