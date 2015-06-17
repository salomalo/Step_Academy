using Client.ServiceNS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch _stop = new Stopwatch();

            PrintSomethingClient _client = new PrintSomethingClient();

            _stop.Start();
            _client.PrintSomething_OneWay("OneWay");
            Console.WriteLine("OneWay"+_stop.ElapsedMilliseconds);
           // Thread.Sleep;

            _stop.Restart();
            _client.PrintSomething_Responce("Responce");
            Console.WriteLine("Responce"+_stop.ElapsedMilliseconds);
            

        }

    }
}
