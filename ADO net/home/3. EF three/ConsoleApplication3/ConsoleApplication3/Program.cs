using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{

    class Program
    {

        static void Main(string[] args)
        {

            using (var ctx = new Context())
            {
                var newCustumers = new Customers()
                {
                    Id = 1,
                    Name = "very new custumer",
                    Address = "Rivne",
                    Phone = "21-32-32",

                };

                ctx.Custumerss.Add(newCustumers);
                ctx.SaveChanges();
            }


        }
    }
}
