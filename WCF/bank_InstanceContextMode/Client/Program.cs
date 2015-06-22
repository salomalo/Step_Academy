using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.ServiceNS;


namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BankServiceClient _client = new BankServiceClient();
            Console.WriteLine("Укажите сумму депозита:");
            double sum = Convert.ToDouble(Console.ReadLine());
            double result = 0;

            while (sum > 0)
            {
                _client.ToDeposit(sum);
                result = _client.GetBalance();
                Console.WriteLine("Депозит = {0}", result);
                Console.WriteLine("Укажите сумму депозита:");
                sum = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Для завершения нажмите<ENTER>\n\n");
            Console.ReadLine();

        }
    }
}
