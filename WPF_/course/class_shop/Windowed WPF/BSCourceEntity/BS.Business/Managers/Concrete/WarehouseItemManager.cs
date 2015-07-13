using BS.Business.Managers.Abstract;
using BS.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BS.Business.Managers.Concrete
{
    public class WarehouseItemManager : AbstractManager, IWarehouseItemManager
    {
        public WarehouseItemManager(string cs) : base(cs) { }


        public IEnumerable<WareHouseItems> GetAll()
        {
            using (DbContext ctx = CreateDbContext())
            {
                return ctx.Set<WareHouseItems>().ToList();
            }
        }

        public void Insert(WareHouseItems newProd)
        {
            using (DbContext ctx = CreateDbContext())
            {
                ctx.Set<WareHouseItems>().Add(newProd);
                ctx.SaveChanges();
            }

        }



    }
}
