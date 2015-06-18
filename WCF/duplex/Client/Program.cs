using Client.ServiceNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class CallBackHendler : IDuplexCallback
    {
        static InstanceContext insCont = new InstanceContext(new CallBackHendler());
        public static DuplexClient duClient = new DuplexClient(insCont);

        public void ReciveTime(string time)
        {
            Console.WriteLine(time);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            CallBackHendler.duClient.CallClientMethod(100, 10);
            Console.ReadLine();


        }

    }

}
