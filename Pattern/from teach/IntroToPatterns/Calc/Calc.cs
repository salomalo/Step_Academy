using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalc
{
    public interface ILogger
    {
        void Log(string arg);
    }

    public class Calc
    {
        private readonly ILogger log;
        public Calc(ILogger log)
        {
            this.log = log;
        }
        public int Add(int a, int b)
        {
            var res = a + b;
            //Console.WriteLine("Add({0},{1}) = {2}",a,b,res);
            log.Log(string.Format("Add({0},{1}) = {2}", a, b, res));

                        
            return res;
        }
    }
}
