using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_LeftJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new testEntities())
            {
                var res = from pg in ctx.Packages
                          join pr in ctx.Products
                          on pg.ProductId equals pr.Id into pgGroup
                          from pr in pgGroup.DefaultIfEmpty()
                          
                          join prod in ctx.Producers
                          on pr.ProducerId equals prod.Id 
                          into prodGroup
                          from prod in prodGroup.DefaultIfEmpty() 

                          select new { 
                            Id = pg.Id,
                            Title = pr.Name,
                            Producer = prod == null ? "No Producer" : prod.Name
                          };

                foreach (var p in res)
                {
                    Console.WriteLine(
                            p.Id
                            + " " +
                            p.Title
                            + " " +
                            p.Producer
                        );
                }
            }
        }
    }
}
