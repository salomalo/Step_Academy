using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamespacesSamp
{
   partial class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            pr.Hello();
            Second.Program p = new Second.Program();
            Second.Program2 p2 = new Second.Program2();
            p.Hello();
            InOtherFileClass ino = new InOtherFileClass();
        }

        public void Hello()
        {
            Console.WriteLine("NamespacesSamp.Program  Hello");
        }
    }

}




namespace Second
{
    class Program
    {
        public void Hello()
        {
            Console.WriteLine("Second.Program  Hello");
        }
    }

    class Program2
    {
        public void Hello()
        {
            Console.WriteLine("Second.Program2  Hello");
        }
    }
}


