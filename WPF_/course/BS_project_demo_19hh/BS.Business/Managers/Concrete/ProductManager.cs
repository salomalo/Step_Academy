using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class ProductManager : AbstractManager, IProductManager
    {
        public ProductManager(string cs) : base(cs) { }

        public IEnumerable<Product> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Product>().ToList();
            }
        }
    }
}
