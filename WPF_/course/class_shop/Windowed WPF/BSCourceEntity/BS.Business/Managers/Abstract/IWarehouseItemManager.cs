using BS.Entity;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IWarehouseItemManager : IManager
    {
        IEnumerable<WareHouseItems> GetAll();
        void Insert(WareHouseItems newWarehousesItem);
    }
}
