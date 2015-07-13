using BS.Business.Managers.Abstract;
using BS.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class CustomerManager : AbstractManager, ICustomerManager
    {
        public CustomerManager(string cs) : base(cs) { }

        public IEnumerable<Customers> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Customers>().ToList();
            }
        }
    }
}
