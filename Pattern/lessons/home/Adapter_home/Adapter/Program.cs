using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdapteeLibrary;

namespace Adapter
{
    class Program
    {
        public class Client
        {
            private readonly ITarget target;
            public Client(ITarget _target)
            {
                target = _target;
            }
            public void ShowStr()
            {
                String str = target.GetString();
                Console.WriteLine(str);
            }
        }

        public interface ITarget
        {
            String GetString();
        }

        public class Adapter : ITarget
        {
            private readonly AdapteeLCDDisplay old;

            public Adapter()
            {
                old = new AdapteeLCDDisplay();
            }

            public string GetString()
            {
                string str = Encoding.UTF8.GetString(old.ByteArr(), 0, old.ByteArr().Length);
                return str;
            }
        }

        static void Main(string[] args)
        {
            ITarget tar = new Adapter();
            Client thirdSys = new Client(tar);
            thirdSys.ShowStr();
        }

    }
}