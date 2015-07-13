using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class ProductManager : AbstractManager, IProductManager
    {
        public ProductManager(string connectionString) : base(connectionString) { }

        public IEnumerable<Product> GetAll()
        {
            using (DbContext ctx = this.CreateDbContext())
            {
                return ctx.Set<Product>().ToList();
            }
        }

    }
}
