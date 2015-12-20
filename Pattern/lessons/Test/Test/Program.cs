using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lista = new List<int>();
            List<int> listb = new List<int>();

            lista.Add(1);
            lista.Add(2);
            lista.Add(3);
            lista.Add(4);

            listb.Add(4);
            listb.Add(5);
            listb.Add(6);
            listb.Add(3);

            List<int> res=Find(lista, listb);
            Show(res);
        }

        public static void Show(List<int> listb)
        {
            foreach (int b in listb)
            {
                Console.WriteLine(b.ToString());
            }
        }


        public static List<int> Find(List<int> lista, List<int> listb)
        {
            List<int> tmp = new List<int>();
            foreach (int b in listb)
            {
                if (lista.Contains(b) == false)
                {
                    tmp.Add(b);
                }            
            }
            return tmp;
        }
    }
}