using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson
{
    class Program
    {
        static void Main(string[] args)
        {
          List<Message> qwe = 
            FetchAllMessages("pop3.ukr.net", 110, false, "sarah_16", "GreenDay313");


          for (int i=0; i < 10; i++)
          {
              Console.WriteLine(qwe[i].Headers.Subject);
          }

            //foreach (Message m in qwe)
            //{
            //    Console.WriteLine(m.Headers.Subject);
            //}
        }

        //http://hpop.sourceforge.net/exampleFetchAllMessages.php
        public static List<Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {
                client.Connect(hostname, port, useSsl);
                client.Authenticate(username, password);

                int messageCount = client.GetMessageCount();

                List<Message> allMessages = new List<Message>(messageCount);
               

                for (int i = messageCount; i > 0; i--)
                {
                    allMessages.Add(client.GetMessage(i));
                }

                // Now return the fetched messages
                return allMessages;
            }
        }

    }
}
