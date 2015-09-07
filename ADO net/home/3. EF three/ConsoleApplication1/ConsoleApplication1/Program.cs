using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DB_Shop_bud_materEntities())
            {
                ctx.Database.Log = Console.WriteLine;

                //foreach (var e in ctx.CustomersType)
                //{
                //    Console.WriteLine(e);
                //}

                foreach (var e in ctx.Customers)
                {
                    Console.WriteLine(e);
                }

            }

        }
    }
}
