using BS.Business.Managers.Abstract;
using BS.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class StatusManager : AbstractManager, IStatusManager
    {
        public StatusManager(string cs) : base(cs) { }

        public IEnumerable<Statuses> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Statuses>().ToList();
            }
        }
    }
}
