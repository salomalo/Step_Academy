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
    public class MeasureManager :  AbstractManager, IMeasureManager
    {
        public MeasureManager(string cs) : base(cs) { }

        public IEnumerable<Measures> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Measures>().ToList();
            }
        }
    }
}
