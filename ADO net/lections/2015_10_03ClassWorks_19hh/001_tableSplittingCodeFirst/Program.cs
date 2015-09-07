using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_tableSplittingCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EmployeeDbContext())
            {
                ctx.Entry(new Employee()).State =
                    System.Data.Entity.EntityState.Unchanged;
                ctx.SaveChanges();
            }
        }
    }
}
