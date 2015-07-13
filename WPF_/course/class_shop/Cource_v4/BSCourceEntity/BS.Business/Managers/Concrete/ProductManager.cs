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
    public class ProductManager :  AbstractManager, IProductManager
    {
        public ProductManager(string cs) : base(cs) { }

        public IEnumerable<Products> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Products>().ToList();
            }
        }
    }
}
