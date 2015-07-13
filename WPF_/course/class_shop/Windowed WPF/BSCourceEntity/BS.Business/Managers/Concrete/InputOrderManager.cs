using BS.Business.Managers.Abstract;
using BS.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class InputOrderManager : AbstractManager, IInputOrderManager
    {
        public InputOrderManager(string cs) : base(cs) { }

        public IEnumerable<InputOrders> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<InputOrders>().ToList();
            }
        }
    }
}
