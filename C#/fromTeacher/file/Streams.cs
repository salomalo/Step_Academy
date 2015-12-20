using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamsFiles
{
    class Program
    {
        static void Main(string[] args)
        {

          //  Stream - base class
            //String path = @"D:/hello.cs";
            String direct = "D:";
            String fileName = "hello.cs";
            String fileText = "text.txt";
            String path = Path.Combine(direct, fileName);
            //FileStream fs = null;
            //int code;
            //try
            //{
            //   fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
            ///*    do
            //    {
            //        code =  fs.ReadByte();
            //        Console.Write((char)code);
            //    }while(code != -1);*/
            //    long length = fs.Length;
            //    byte[] buffer = new byte[300];
            //    string content = String.Empty;
            //    while(fs.Read(buffer, 0, buffer.Length) > 0)
            //    {
            //        content += Encoding.UTF8.GetString(buffer);                        
            //    }

            //    Console.WriteLine(content);
            //  //  throw new IOException();



            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    fs.Close();
            //    //fs.Dispose(); - the same to close
            //}
            //Console.ReadLine();
            //--------------------------------------------------------------------
            //string textToWrite = " 123456";
            //try
            //{
            //    using (FileStream fsW = new FileStream(Path.Combine(direct, fileText), FileMode.Append, FileAccess.Write, FileShare.None))
            //    {
            //        byte [] arr = Encoding.UTF8.GetBytes(textToWrite);
            //        fsW.Write(arr, 0, arr.Length);
            //    }
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //---------------------------------------------------------------------------

            //try
            //{
            // /*   using (FileStream fst = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))   //після виходу з блоку викликає метод Dispose
            //    {
            //        StreamReader sr = new StreamReader(fst);
            //    }*/

            //    using (StreamReader sr = new StreamReader(path))   
            //    {
            //        string str = sr.ReadToEnd();                    
            //        Console.WriteLine(str);
            //    }

            //    using (StreamWriter sw = new StreamWriter(Path.Combine(direct, fileText), true, Encoding.UTF8))
            //    {
            //        string str = "SOME TEXT";

            //        sw.WriteLine(str);
            //    }
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            try
            {
                int i = 10;
                string str = "str";
                double d = 2.5;
                using ( FileStream fs = new FileStream(Path.Combine(direct, fileText), FileMode.OpenOrCreate))
                {
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(i);
                    bw.Write(d);
                    bw.Write(str);
                }

                using (FileStream fs = new FileStream(Path.Combine(direct, fileText), FileMode.Open))
                {
                    BinaryReader br = new BinaryReader(fs);
                    int k = br.ReadInt32();
                    string str2 = br.ReadString();
                    double dob = br.ReadDouble();

                    Console.WriteLine(k);
                    Console.WriteLine(str2);
                    Console.WriteLine(dob);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
