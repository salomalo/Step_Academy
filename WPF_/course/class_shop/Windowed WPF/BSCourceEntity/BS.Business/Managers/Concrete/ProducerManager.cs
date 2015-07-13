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
    public class ProducerManager:  AbstractManager, IProducerManager
    {
        public ProducerManager(string cs) : base(cs) { }

        public IEnumerable<Producers> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Producers>().ToList();
            }
        }
        public void Insert(Producers newProduser)
        {
            using (DbContext ctx = CreateDbContext())
            {
                ctx.Set<Producers>().Add(newProduser);
                ctx.SaveChanges();
            }

        }
    }
}
