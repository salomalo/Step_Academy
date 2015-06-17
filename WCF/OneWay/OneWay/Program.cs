using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OneWay
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(PrintSomething));
            sh.Open();

            Console.WriteLine("enter");
            Console.ReadLine();
        }
    }

    [ServiceContract]
    public interface IPrintSomething
    {
        [OperationContract]
        void PrintSomething_Responce(string tmp);
        [OperationContract(IsOneWay = true)]
        void PrintSomething_OneWay(string tmp);
    }

    public class PrintSomething : IPrintSomething
    {
        public void PrintSomething_OneWay(string tmp)
        {
            Console.WriteLine(tmp);
        }

        public void PrintSomething_Responce(string tmp)
        {
            Console.WriteLine(tmp);
        }
    }




}
