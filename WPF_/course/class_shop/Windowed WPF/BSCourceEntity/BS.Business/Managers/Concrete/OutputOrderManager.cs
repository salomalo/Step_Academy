using BS.Business.Managers.Abstract;
using BS.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class OutputOrderManager : AbstractManager, IOutputOrderManager
    {
        public OutputOrderManager(string cs) : base(cs) { }

        public IEnumerable<OutputOrders> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<OutputOrders>().ToList();
            }
        }
    }
}