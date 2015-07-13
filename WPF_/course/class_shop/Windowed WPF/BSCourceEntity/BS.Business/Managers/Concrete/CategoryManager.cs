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
    public class CategoryManager : AbstractManager, ICategoryManager
    {
        public CategoryManager(string cs) : base(cs) { }

        public IEnumerable<Categories> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<Categories>().ToList();
            }
        }
        public void Insert(Categories newCat)
        {
            using (DbContext ctx = CreateDbContext())
            {
                ctx.Set<Categories>().Add(newCat);
                ctx.SaveChanges();
            }
           
        }

        public void Update(int Id, string name)
        {
            Categories entity;
            using (DbContext ctx = CreateDbContext())
            {
                entity = ctx.Set<Categories>().Find(Id);
            }
            if (entity != null)
            {
                entity.Name = name;
            }
            using (DbContext ctx = CreateDbContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            
        }
    }
}
