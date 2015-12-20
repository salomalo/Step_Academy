using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBridg
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageSenderBridg imes = new UserConcret();

            MessageAbstraction mesabs = new UserMessRefund();
            mesabs.Body = "body";
            mesabs.Subject = "sub";

            mesabs.MessageSenderBridg = imes;
            mesabs.Send();
        }


        public abstract class MessageAbstraction
        {
            public IMessageSenderBridg MessageSenderBridg { get; set; }

            public string Body { get; set; }
            public string Subject { get; set; }    
            public abstract void Send();
        }

        public interface IMessageSenderBridg
        {
            void SendMess(string Subject,string Body);
        }

        public class UserMessRefund : MessageAbstraction
        {
            public override void Send()
            {
                MessageSenderBridg.SendMess(Subject,Body);
            }
        }

        public class UserConcret : IMessageSenderBridg
        {
            public void SendMess(string Subject, string Body)
            {
                Console.WriteLine(" sub: {0} body: {1} ", Subject, Body);
            }
        }


    }
}
