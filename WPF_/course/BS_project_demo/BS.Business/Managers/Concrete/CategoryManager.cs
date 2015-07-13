using BS.Business.Managers.Abstract;
using BS.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class CategoryManager : AbstractManager, ICategoryManager
    {
        public CategoryManager(string connectionString) : base(connectionString) { }

        public IEnumerable<Category> GetAll()
        {
            using (DbContext ctx = this.CreateDbContext())
            {
                return ctx.Set<Category>().ToList();
            }
        }

    }
}
