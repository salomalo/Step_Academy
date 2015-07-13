using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class ProducerManager : AbstractManager, IProducerManager 
    {
        public ProducerManager(string cs) : base(cs) { }

        public IEnumerable<Producer> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Producer>().ToList();
            }
        }
    }
}
