using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class PriceManager : AbstractManager, IPriceManager
    {
        public PriceManager(string connectionString) : base(connectionString) { }

        public IEnumerable<Price> GetAll()
        {
            using (DbContext ctx = this.CreateDbContext())
            {
                return ctx.Set<Price>().ToList();
            }
        }

    }
}
