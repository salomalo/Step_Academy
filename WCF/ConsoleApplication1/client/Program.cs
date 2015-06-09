using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//24 st
namespace client
{
    class Program
    {
        static void Main(string[] args)
        {

            ChannelFactory<IMyMath>factory =new ChannelFactory<IMyMath>(
                new WSHttpBinding()
                ,new EndpointAddress("http://localhost/MyMath/Ep1"));

            IMyMath channel = factory.CreateChannel();
            int result = channel.Add(3,5);
            Console.WriteLine(result);
        }
    }

    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }

}
