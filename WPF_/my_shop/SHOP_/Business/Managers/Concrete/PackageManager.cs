using Business.Managers.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Managers.Concrete
{
    public class PackageManager : AbstractManager, IPackageManager
    {
        public PackageManager(string cs) : base(cs) { }

        public IEnumerable<Packeges> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Packeges>().ToList();
            }
        }
    }
}
