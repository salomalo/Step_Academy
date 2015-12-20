using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactMet
{
    class Program
    {
        abstract class CompareProdact // abstracr product
        {
            public abstract string DoCompare(string a, string b);
        }

        abstract public class AbstractCreator // abstract creator
        {
            public CompareProdact FactoryMethod();
        }

        public class ConcretCreator : AbstractCreator
        {
            public override CompareProdact FactoryMethod()
            {
                return new TxtCompareProd();
            }
        }

        public class TxtCompareProd : CompareProdact
        {
            public override string  DoCompare(string a, string b)
            {
                if(String.Compare(a, b) > 1)
                    return a;
                else
                    return b;
            }

        }
        public class IntCompareProd : CompareProdact
        {
            public override int DoCompare(string a, string b)
            {
               return  a.CompareTo(b);
            }

        }

        static void Main(string[] args)
        {
            AbstractCreator a = new ConcretCreator();
            CompareProdact p = a.FactoryMethod();

               Console.WriteLine( p.DoCompare("3","3"));


        }


    }
}
