using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApplication3
{
    class Context : DbContext
    {
        public DbSet<Customers> Custumerss { set; get; }
        public DbSet<CustomersType> CustumersTypes { set; get; }
    }
}
