using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace MyDiskInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(GetDiskInfo), new Uri("http://localhost/GetDiskInfo/"));
            //ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            //behavior.HttpGetEnabled = true;
            //sh.Description.Behaviors.Add(behavior);
            //sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
            sh.Open();
            Console.WriteLine("enter");
            Console.ReadLine();
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

    public class GetDiskInfo : IGetDiskInfo
    {
        public string FreeSpace(string diskName)
        {
            DriveInfo di = new DriveInfo(diskName);
            int res = (int)di.TotalFreeSpace;
            return res.ToString();
        }

        public string TotalSpace(string diskName)
        {
            DriveInfo di = new DriveInfo(diskName);
            int res = (int)di.TotalSize;
            return res.ToString();
        }
    }

}
