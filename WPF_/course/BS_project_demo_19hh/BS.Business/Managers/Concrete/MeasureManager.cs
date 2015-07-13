using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class MeasureManager : AbstractManager, IMeasureManager
    {
        public MeasureManager(string cs) : base(cs) { }

        public IEnumerable<Measure> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Measure>().ToList();
            }
        }
    }
}
