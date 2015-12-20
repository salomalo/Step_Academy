using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxySubject proxy = new ProxySubject();

            var str = proxy.GetData();

            Console.WriteLine("Str: {0}", str);

            Console.Read();

        }
    }

    interface ISomeData
    {
        string GetData();
    }

    class RealSubject : ISomeData
    {
        string _data;
        public RealSubject(string data)
        {
            Console.WriteLine("RealSubject ctor()");
            _data = data;
        }

        //perform action
        public string GetData()
        {
            return _data;
        }
    }

    class ProxySubject : ISomeData
    {
        RealSubject _subj;

        public ProxySubject()
        {
            Console.WriteLine("ProxySubject ctor()");
        }

        public string GetData()
        {

            

            Console.WriteLine("GetData call");

            if (_subj == null)
            {
                _subj = new RealSubject("some pretty data");
            }

            return _subj.GetData();
        }
    }
}
