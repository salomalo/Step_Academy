using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridg
{
    class Program
    {
        static void Main(string[] args)
        {
            IMessageSender email = new EmailSender();
            IMessageSender web = new WebServiceSender();

            //системне повідомлення
            Message message = new SystemMessage();
            message.Subject = "Test Message";
            message.Body = "Text message body";

            //надсилаємо через електронну пошту
            message.MessageSender = email;
            message.Send();

            //надсилаємо на веб-сервіс
            message.MessageSender = web;
            message.Send();

            //користувацьке повідомлення
            UserMessage usermsg = new UserMessage();
            usermsg.Subject = "Test message subject";
            usermsg.Body = "Another text message body";
            usermsg.UserComments = "Some user comments";

            usermsg.MessageSender = email;
            usermsg.Send();

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Абстрактний клас
    /// </summary>
    public abstract class Message
    {
        //мостова операція/імплементатор/міст реалізації
        public IMessageSender MessageSender { get; set; }
        //private IMessageSender MessageSender1 { get; set; }
        
    
        public string Subject { get; set; }
        public string Body { get; set; }
        public abstract void Send();

        //public void BridgeOpn(...)
        //{
        //    MessageSender1.SendMessage();
        //}
    }


    //implementer?
    /// <summary>
    /// Мостовий інтерфейс
    /// </summary>
    public interface IMessageSender
    {
        void SendMessage(string subject, string body);
    }


    /// <summary>
    /// Уточнений клас A
    /// </summary>
    public class SystemMessage : Message
    {
        public override void Send()
        {
            MessageSender.SendMessage(Subject, Body);
        }
    }

    /// <summary>
    /// Ще один уточнений клас
    /// </summary>
    public class UserMessage : Message
    {
        public string UserComments { get; set; }

        public override void Send()
        {
            string fullBody = string.Format("{0}\nUser Comments: {1}", Body, UserComments);
            MessageSender.SendMessage(Subject, fullBody);
        }
    }

    /// <summary>
    /// Клас конкретного виконавця А
    /// </summary>
    public class EmailSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine("Email\n{0}\n{1}\n", subject, body);
        }
    }

    /// <summary>
    /// Клас конкретного виконавця B
    /// </summary>
    public class WebServiceSender : IMessageSender
    {
        public void SendMessage(string subject, string body)
        {
            Console.WriteLine("Web Service\n{0}\n{1}\n", subject, body);
        }
    }

}
