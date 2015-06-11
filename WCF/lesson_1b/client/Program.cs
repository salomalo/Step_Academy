using client.ServiceNS;
using System;
//24 st
namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient a = new MyMathClient();
            int result = a.Add(3, 7);



            //ChannelFactory<IMyMath>factory =new ChannelFactory<IMyMath>(
            //    new WSHttpBinding()
            //    ,new EndpointAddress("http://localhost/MyMath/Ep1"));

            //IMyMath channel = factory.CreateChannel();
            //int result = channel.Add(3,5);
            Console.WriteLine(result);
            a.Close();
        }
    }


    //[ServiceContract]
    //public interface IMyMath
    //{
    //    [OperationContract]
    //    int Add(int a, int b);
    //}








}
