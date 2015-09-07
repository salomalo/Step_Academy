using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_manyToMany_withBridge_codeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new StudentDbContext())
            {
                ctx.Entry(new Student()).State = System.Data.Entity.EntityState.Unchanged;
                ctx.SaveChanges();
            }
        }
    }
}
