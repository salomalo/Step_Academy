using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

//using Client_Proxy.ServiceReference1;


using Client_Proxy.ServiceReference2Async;


namespace Client_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDiskInfoClient GetDisk= new GetDiskInfoClient(); // відображення сервайс контракта
            DiskResult res = GetDisk.Res("D"); // метод повертає обєкт класу DiskResult
         
            //Async functions 
            IAsyncResult aR = GetDisk.BeginRes("D", new System.AsyncCallback(callback), res);
                      
            //GetDisk.EndRes(


            string resTotalSpace = res.TotalSpace;
            string resFreeSpace = res.FreeSpace;
            Console.WriteLine("resTotalSpace - {0}; resFreeSpace - {1}", resTotalSpace, resFreeSpace);

        }

        private static void callback(IAsyncResult ar)
        {
            DiskResult res = ((GetDiskInfoClient)ar.AsyncState).EndRes(ar);
            string resTotalSpace = res.TotalSpace;
            string resFreeSpace = res.FreeSpace;
            Console.WriteLine("resTotalSpace - {0}; resFreeSpace - {1}", resTotalSpace, resFreeSpace);
        }
    }


}

