using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _008_deadlock
{
    public class Account
    {
        double _balance;
        int _id;

        public int Id
        {
            get { return _id; }
        }

        public double Balance
        {
            get { return _balance; }
        }

        public Account(int id, double balance)
        {
            _id = id;
            _balance = balance;
        }

        public void Withdraw(double amount)
        {
            _balance -= amount;
        }

        public void Deposite(double amount)
        {
            _balance += amount;
        }
    }

    public class AccountManager
    {

        Account _fromAccount;
        Account _toAccount;
        double _amountToTransfer;

        public AccountManager(Account from, Account to, double amount)
        {
            _fromAccount = from;
            _toAccount = to;
            _amountToTransfer = amount;
        }

        public void Transfer()
        {
            object _lock1, _lock2;

            if (_fromAccount.Id < _toAccount.Id)
            {
                _lock1 = _fromAccount;
                _lock2 = _toAccount;
            }
            else
            {
                _lock2 = _fromAccount;
                _lock1 = _toAccount;
            }

            lock (_lock1)
            {
                Thread.Sleep(1000);

                lock (_lock2)
                {
                    _fromAccount.Withdraw(_amountToTransfer);
                    _toAccount.Deposite(_amountToTransfer);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Main started: ");
            // Account accountA = new Account(101, 5000);
            // Account accountB = new Account(102, 3000);
            // 
            // AccountManager accountManagerA = new AccountManager(accountA, accountB, 1000);
            // Thread t1 = new Thread(accountManagerA.Transfer);
            // 
            // AccountManager accountManagerB = new AccountManager(accountB, accountA, 2000);
            // Thread t2 = new Thread(accountManagerB.Transfer);
            // 
            // //t1.Start(); t1.Join();
            // //t2.Start(); t2.Join();
            // 
            // t1.Start(); t2.Start();
            // t1.Join(); t2.Join();
            // 
            // Console.WriteLine("account1.Balance : " + accountA.Balance);
            // Console.WriteLine("account2.Balance : " + accountB.Balance);
            // 
            // Console.WriteLine("Main finished: ");

            Console.WriteLine("Processors : " + Environment.ProcessorCount);

        }
    }
}
