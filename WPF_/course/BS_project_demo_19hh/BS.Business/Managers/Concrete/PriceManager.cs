using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class PriceManager : AbstractManager, IPriceManager
    {
        public PriceManager(string cs) : base(cs) { }

        public IEnumerable<Price> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Price>().ToList();
            }
        }
    }
}
