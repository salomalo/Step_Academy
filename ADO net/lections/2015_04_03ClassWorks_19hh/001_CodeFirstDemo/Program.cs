using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new  EmployeeDBContext())
            {
                ctx.Entry(new Employee()).State = EntityState.Unchanged;
                ctx.SaveChanges();
            }
        }
    }
}
