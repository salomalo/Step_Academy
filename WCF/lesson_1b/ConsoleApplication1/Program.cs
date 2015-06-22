using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath),new Uri("http://localhost/MyMath/Ep1"));
          
            sh.AddServiceEndpoint(typeof(IMyMath), new WSHttpBinding(), "http://localhost/MyMath/Ep1");
            // новий обєкт поведінки
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            //дозволяємо доступ по протоколу Http
            behavior.HttpGetEnabled = true;
            //додаємо нову поведінку в опис служби
            sh.Description.Behaviors.Add(behavior);
            //додаємо мекс - це точка призначена для отримання метаданих сервіса клієнтами
            sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            sh.Open();

            Console.WriteLine("enter");
            Console.ReadLine();
            sh.Close();
        }
    }


    [ServiceContract ]  // контракт служби
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
        [OperationContract]
        int Divide(int x);
    }

    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MyMath : IMyMath
    {       
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Divide(int x)
        {
            int b = 0 ;
            return x/b;
        }

    }



    
}
