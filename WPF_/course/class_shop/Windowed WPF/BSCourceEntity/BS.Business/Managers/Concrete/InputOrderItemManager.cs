using BS.Business.Managers.Abstract;
using BS.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class InputOrderItemManager : AbstractManager, IInputOrderItemManager
    {
        public InputOrderItemManager(string cs) : base(cs) { }

        public IEnumerable<InputOrderItems> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<InputOrderItems>().ToList();
            }
        }
    }
}
