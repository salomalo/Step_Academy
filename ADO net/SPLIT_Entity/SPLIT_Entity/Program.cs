using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLIT_Entity
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DB_Shop_bud_materEntities())
            {
                foreach (var e in ctx.Customers)
                {
                    if (e.Id % 2 != 0)
                    {
                        Console.WriteLine(
                            e.Id
                            + " " +
                            e.Name
                            + " " +
                            e.Phone
                            );
                    }
                    if (e.Id % 2 == 0)
                    {
                        Console.WriteLine(
                                e.Id
                                + " " +
                                e.CustumerDetail.Mobile
                                + " " +
                                e.CustumerDetail.JurAddress
                                + " " +
                                e.CustumerDetail.BankAccount
                                + " " +
                                e.CustumerDetail.Email
                                + " " +
                                e.CustumerDetail.Address
                                );
                    }
                }
                Console.WriteLine("\n----------");
            }

        } // main
    }
}