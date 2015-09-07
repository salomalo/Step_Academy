using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitySplitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new testEntities())
            {
                foreach (var e in ctx.Employees)
                {
                    Console.WriteLine(
                            e.Id
                            + " " +
                            e.Name
                            + " " +
                            e.Salary
                        );
                }
            }

        }
    }
}
