using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class ProducerManager : AbstractManager, IProducerManager
    {
        public ProducerManager(string connectionString) : base(connectionString) { }

        public IEnumerable<Producer> GetAll()
        {
            using (DbContext ctx = this.CreateDbContext())
            {
                return ctx.Set<Producer>().ToList();
            }
        }

    }
}
