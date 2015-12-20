using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter lines count: ");
            int count = Convert.ToInt32(Console.ReadLine());

            AbstractTextHandler currentHandler = null;
            AbstractTextHandler rootHandler = null;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter line #{0}", i + 1);
                var txtData = Console.ReadLine();

                if (currentHandler == null)
                {
                    currentHandler = new ConcreteTextHandler { LineNumber = i + 1, TextData = txtData };
                    rootHandler = currentHandler;
                }
                else
                {
                    var next = new ConcreteTextHandler { LineNumber = i + 1, TextData = txtData };
                    currentHandler.SetSuccessor(next);
                    currentHandler = next;
                }
            }

            Console.WriteLine("Enter pos to rollback: ");
            int rollbackLine = Convert.ToInt32(Console.ReadLine());

            var txt = rootHandler.ProcessRequest(rollbackLine);
            Console.WriteLine("Text on pos: {0}", txt);

            Console.ReadKey();
        }
    }

    //абстрактний хендлер
    abstract class AbstractTextHandler
    {
        protected AbstractTextHandler Successor;

        public AbstractTextHandler SetSuccessor(AbstractTextHandler successor)
        {
            Successor = successor;
            return successor;
        }
        public abstract string ProcessRequest(int line);
    }


    class ConcreteTextHandler : AbstractTextHandler
    {
        public int LineNumber { get; set; }
        public string TextData { get; set; }
        
        public override string ProcessRequest(int line)
        {
            if (LineNumber == line)
            {
                return TextData;
            }

            if (Successor != null)
            {
                return Successor.ProcessRequest(line);
            }

            return null; // string.empty // default (T)
        }
    }
}