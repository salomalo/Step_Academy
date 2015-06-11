using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Client_Proxy.ServiceNS;


namespace Client_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            GetDiskInfoClient GetDisk = new GetDiskInfoClient();
            string result = GetDisk.FreeSpace("D");

            Console.WriteLine(result);
        }
    }

    [ServiceContract]
    public interface IGetDiskInfo
    {
        [OperationContract]
        string FreeSpace(string diskName);
        [OperationContract]
        string TotalSpace(string diskName);
    }

}

