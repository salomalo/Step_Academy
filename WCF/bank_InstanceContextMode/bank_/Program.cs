using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace bank_
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(BankService));

            sh.Open();
            Console.WriteLine("Для завершения нажмите<ENTER>\n\n");
            Console.ReadLine();
            sh.Close();

        }
    }

    //контракт службы	
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        void ToDeposit(double sum);
        [OperationContract]
        double GetBalance();
    }

    //класс службы	
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    //[ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class BankService : IBankService
    {
        static int id = 0;		//для нумерации создаваемых счетов
        public double Balance;	//баланс счета

        //создание нового счета
        public BankService()
        {
            ++id;
            Console.WriteLine("Создан счет № " + id.ToString());
        }
        //перевод денег на созданный счет
        public void ToDeposit(double sum)
        {
            Balance += sum;
        }

        //вывод текущего баланса счета
        public double GetBalance()
        {
            return Balance;
        }
    }





}
