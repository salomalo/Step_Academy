using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class PackageManager : AbstractManager, IPackageManager
    {
        public PackageManager(string cs) : base(cs) { }

        public IEnumerable<Package> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Package>().ToList();
            }
        }
    }
}
