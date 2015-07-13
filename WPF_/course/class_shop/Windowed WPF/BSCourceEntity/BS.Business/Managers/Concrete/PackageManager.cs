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
    public class PackageManager:  AbstractManager, IPackageManager
    {
        public PackageManager(string cs) : base(cs) { }

        public IEnumerable<Packages> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Packages>().ToList();
            }
        }

        public int Insert(Packages newPack)
        {
            int Id;
            using (DbContext ctx = CreateDbContext())
            {
                ctx.Set<Packages>().Add(newPack);
                ctx.SaveChanges();

            }
            
            using (DbContext ctx = CreateDbContext())
            {
                var entity = ctx.Entry(newPack);
                Id = entity.Entity.Id;
               // entity.Entity.Id
            }
            return Id;
        }
    }
}
