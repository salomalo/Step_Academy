using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace duplex
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Duplex));
            sh.Open();
            Console.WriteLine("enter");
            Console.ReadLine();
            sh.Close();
        }
    }

    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReciveTime(string time); // сервіс знатиме що виклик у кліжнта( він буде реалізований у клієнта
    }

    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IDuplex
    {
        [OperationContract(IsOneWay = true)]
        void CallClientMethod(int period, int count);
    }

    public class Duplex : IDuplex
    {
        public void CallClientMethod(int period, int count)
        {
            //var _IclCall = new IClientCallback;
            //_IclCall.ReciveTime(DateTime.Now.ToString());

            ClientCaller _clientCaller = new ClientCaller();
            _clientCaller._IclCall = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            Thread th = new Thread(_clientCaller.SendDataToClient);
            th.IsBackground = true;
            List<int> _lis = new List<int>();
            _lis.Add(period);
            _lis.Add(count);
            th.Start(_lis);
        }
    }


    public class ClientCaller //створений для роботи в окр потоці 
    {
        public IClientCallback _IclCall;
        public void SendDataToClient(object obj)
        {
            List<int> tmp = (List<int>)obj;
            int period = tmp[0];
            int count = tmp[1];
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(period);
                try
                {
                    _IclCall.ReciveTime(DateTime.Now.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

}
