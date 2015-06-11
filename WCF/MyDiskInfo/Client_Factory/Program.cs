using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IGetDiskInfo> factory = new ChannelFactory<IGetDiskInfo>(
               new WSHttpBinding()
               , new EndpointAddress("http://localhost/GetDiskInfo/Ep1"));
            IGetDiskInfo channel = factory.CreateChannel();
            string result = channel.FreeSpace("D");
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
