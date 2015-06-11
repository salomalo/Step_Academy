using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace MyDiskInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(GetDiskInfo), new Uri("http://localhost/GetDiskInfo/"));
            sh.Open();
            Console.WriteLine("enter");
            Console.ReadLine();
        }
    }
    
    [DataContract]
    public class DiskResult
    {
        [DataMember]
        public string FreeSpace;
        [DataMember]
        public string TotalSpace;
    }

    [ServiceContract]
    public interface IGetDiskInfo
    {
        [OperationContract]
        DiskResult Res(string diskName);
        [OperationContract]
        DiskResult ResRes(string diskName, string discSecond);
    }

    public class GetDiskInfo : IGetDiskInfo
    {
        public DiskResult Res(string diskName)
        {
            DriveInfo di = new DriveInfo(diskName);
            DiskResult Res = new DiskResult();
            Res.FreeSpace = di.TotalFreeSpace.ToString();
            Res.TotalSpace = di.TotalSize.ToString();
            return Res; // вертаю цілий обєкт
        }

        public DiskResult ResRes(string diskName, string discSecond)
        {
            DriveInfo di = new DriveInfo(diskName);
            DiskResult Res = new DiskResult();
            Res.FreeSpace = di.TotalFreeSpace.ToString();
            Res.TotalSpace = di.TotalSize.ToString();
            return Res; // вертаю цілий обєкт
        }

    }


}
