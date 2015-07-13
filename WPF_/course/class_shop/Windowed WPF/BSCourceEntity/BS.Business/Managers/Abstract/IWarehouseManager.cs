using BS.Entity;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IWarehouseManager : IManager
    {
        IEnumerable<WareHouses> GetAll();
        void Insert(WareHouses newWarehouses);
        void Update(int Id, string name);
    }
}
