using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Duplex));
            sh.Open();
            Console.WriteLine("enter\n\n");
            Console.ReadLine();
            sh.Close();
        }//Main
    }//Program


    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void DeliverMessage(string time); // сервіс знатиме що виклик у кліжнта( він буде реалізований у клієнта

        [OperationContract(IsOneWay = true)]
        void SendMessage(string time);
    } // IClientCallback

    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IDuplex
    {
        [OperationContract(IsOneWay = true)]
        void CallClientMethod(string msg);
    } // IDuplex

    public class Duplex : IDuplex
    {
        public void CallClientMethod(string msg)
        {
            ClientCaller _clientCaller = new ClientCaller();
            _clientCaller._IclCall = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            Thread th = new Thread(_clientCaller.SendDataToClient);
            th.IsBackground = true;

            msg = "some message";

            th.Start(msg);
        }
    } // Duplex


    public class ClientCaller //створений для роботи в окр потоці 
    {
        public IClientCallback _IclCall;
        public void SendDataToClient(object obj)
        {
            string tmp = (string)obj;
            try
            {
                _IclCall.DeliverMessage(tmp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    } // ClientCaller

}
