using BS.Business.Managers.Abstract;
using BS.Entity;
using BS.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Presentation.ViewModels
{
    public class WarehouseViewModel
    {
        private readonly IPackageManager _packageManager;
        private readonly IProductManager _productManager;
        private readonly IProducerManager _producerManager;
        private readonly IWarehouseManager _warehouseManager;
        private readonly IWarehouseItemManager _warehouseItemManager;

        private List<WarehouseModel> _items = null;

        #region Ctor

        public WarehouseViewModel(
             IPackageManager packageManager
            , IProductManager productManager
            , IProducerManager producerManager
            , IWarehouseManager warehouseManager
            , IWarehouseItemManager warehouseItemManager
            )
        {
            _packageManager = packageManager;
            _productManager = productManager;
            _producerManager = producerManager;
            _warehouseManager = warehouseManager;
            _warehouseItemManager = warehouseItemManager;
        }

        #endregion


        static public List<WarehouseModel> CreateWarehouseModel(
            IEnumerable<Packages> pPackages
            , IEnumerable<Products> pProducts
            , IEnumerable<Producers> pProducers
            , IEnumerable<WareHouses> wWarehouse
            , IEnumerable<WareHouseItems> wWareHouseItems
            )
        {
            List<WarehouseModel> listCM = new List<WarehouseModel>();

            var resWarehouses =
                      from waritem in wWareHouseItems
                      join paceg in pPackages
                        on waritem.PackageId equals paceg.Id

                      join product in pProducts
                        on paceg.ProductId equals product.Id

                      join producer in pProducers
                        on product.ProducerId equals producer.Id
                        
                      join warh in wWarehouse
                        on waritem.WareHouseId equals warh.Id


                      select new
                      {
                          Id = waritem.Id,
                          Name = product.Name,
                          Producer = producer.Name,
                          Volume = waritem.Quantity,
                          Warehouse = warh.Adress,
                      };
            
            foreach (var c in resWarehouses)
            {
                listCM.Add(
                        new WarehouseModel(
                             c.Id
                            , c.Name
                            , c.Producer
                            , c.Volume
                            , c.Warehouse
                            )
                    );
            }
            return listCM;
        }

        public IEnumerable<WarehouseModel> Warehouse
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateWarehouseModel(
                        _packageManager.GetAll(),
                        _productManager.GetAll(),
                        _producerManager.GetAll(),
                        _warehouseManager.GetAll(),
                        _warehouseItemManager.GetAll()
                        );
                }

                return _items;

            }
        }
    }
}
