using BS.Business.Managers.Abstract;
using BS.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class OutputOrderItemManager : AbstractManager, IOutputOrderItemManager
    {
        public OutputOrderItemManager(string cs) : base(cs) { }

        public IEnumerable<OutputOrderItems> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<OutputOrderItems>().ToList();
            }
        }
    }
}
