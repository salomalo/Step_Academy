using BS.Business.Managers.Abstract;
using BS.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Business.Managers.Concrete
{
    public class PackageManager : AbstractManager, IPackageManager
    {
        public PackageManager(string connectionString) : base(connectionString) { }

        public IEnumerable<Package> GetAll()
        {
            using (DbContext ctx = this.CreateDbContext())
            {
                return ctx.Set<Package>().ToList();
            }
        }
    }
}
