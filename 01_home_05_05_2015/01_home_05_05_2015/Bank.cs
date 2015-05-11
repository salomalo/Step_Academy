using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_home_05_05_2015
{
    public class Bank
    {
        private int _money;
        private string _name;
        private int _percent;

        public int Money
        {
            set
            {
                _money = value;
                newThread();
            }
            get{return _money;}
        }

        public int Percent
        {
            set
            {
                _percent = value;
                newThread();
            }
            get{return _percent;}
        }

        public string Name
        {
            set
            {
                _name = value;
                newThread();
            }
            get{return _name;}
        }

        public void newThread()
        { 
            ThreadStart ts1 = new ThreadStart(printBank);
            Thread t1 = new Thread(ts1);
            t1.Start();
            t1.Join();
        }

        public void printBank()
        {
          string[] res = {Money.ToString(),Percent.ToString(),Name };
          System.IO.File.WriteAllLines(@"D:\printBank.txt", res);
        }




    } // Bank

}
