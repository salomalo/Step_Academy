using BS.Business.Managers.Abstract;
using BS.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Business.Managers.Concrete
{
    public class PriceManager:  AbstractManager, IPriceManager
    {
        public PriceManager(string cs) : base(cs) { }

        public IEnumerable<Prices> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Prices>().ToList();
            }
        }
    }
}
