using BS.Business.Managers.Abstract;
using BS.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class WarehouseManager : AbstractManager, IWarehouseManager
    {
        public WarehouseManager(string cs) : base(cs) { }


        public IEnumerable<WareHouses> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<WareHouses>().ToList();
            }
        }
        public void Insert(WareHouses newProd)
        {
            using (DbContext ctx = CreateDbContext())
            {
                ctx.Set<WareHouses>().Add(newProd);
                ctx.SaveChanges();
            }

        }


        public void Update(int Id, string name)
        {
            WareHouses entity;
            using (DbContext ctx = CreateDbContext())
            {
                entity = ctx.Set<WareHouses>().Find(Id);
            }
            if (entity != null)
            {
                entity.Adress = name;
            }
            using (DbContext ctx = CreateDbContext())
            {
                ctx.Entry(entity).State = EntityState.Modified;
                ctx.SaveChanges();
            }

        }

    }
}
