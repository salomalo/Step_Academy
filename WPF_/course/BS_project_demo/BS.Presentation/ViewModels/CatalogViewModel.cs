using BS.Business.Managers.Abstract;
using BS.Entities;
using BS.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Presentation.ViewModels
{
    public class CatalogViewModel
    {
        private readonly IPackageManager    _packageManager;
        private readonly IProductManager    _productManager;
        private readonly IProducerManager   _producerManager;
        private readonly ICategoryManager   _categoryManager;
        private readonly IMeasureManager    _measureManager;
        private readonly IPriceManager      _priceManager;

        List<CatalogModel> _items = null;

        #region Ctor

        public CatalogViewModel(
                 IPackageManager   packageManager
                ,IProductManager   productManager 
                ,IProducerManager  producerManager 
                ,ICategoryManager  categoryManager 
                ,IMeasureManager   measureManager 
                ,IPriceManager     priceManager 
            )
        { 
            _packageManager  = packageManager;
            _productManager  = productManager;
            _producerManager = producerManager;
            _categoryManager = categoryManager;
            _measureManager  = measureManager;
            _priceManager    = priceManager;
        }

        #endregion

        static public List<CatalogModel> CreateCatalogModel(
                  IEnumerable<Package> packages
                , IEnumerable<Product> products
                , IEnumerable<Producer> producers
                , IEnumerable<Category> categories
                , IEnumerable<Measure> measures
                , IEnumerable<Price> prices
            )
        {
            List<CatalogModel> listCM = new List<CatalogModel>();

            var res =
                from pg in packages
                join p in products
                    on pg.ProductId equals p.Id
                join c in categories
                    on p.CategoryId equals c.Id
                join cc in categories
                    on c.ParentId equals cc.Id
                join prd in producers
                    on p.ProducerId equals prd.Id
                join m in measures
                    on pg.MeasureId equals m.Id
                join vm in measures
                    on pg.VolumeMeasureId equals vm.Id
                join price in prices
                    on pg.Id equals price.PackageId
                select new { 
                     Id = pg.Id
                    ,Name = p.Name
                    ,Producer = prd.Name
                    ,Category = c.Name
                    ,SubCategory = cc.Name
                    ,Volume = pg.Volume
                    ,VolMeasure = vm.SmallName
                    ,Measure = m.SmallName
                    ,Price = price.UnitCost
                };

            foreach (var c in res)
            {
                listCM.Add(
                        new CatalogModel(
                                 c.Id
                                ,c.Name
                                ,c.Producer
                                ,c.Category
                                ,c.SubCategory
                                ,c.Volume
                                ,c.VolMeasure
                                ,c.Measure
                                ,c.Price
                            )
                    );
            }

            return listCM;

        }

        public IEnumerable<CatalogModel> Catalog
        {
            get {
                if (_items == null)
                {
                    _items = CreateCatalogModel(
                             _packageManager.GetAll()
                            ,_productManager.GetAll()
                            ,_producerManager.GetAll()
                            ,_categoryManager.GetAll()
                            ,_measureManager.GetAll()
                            ,_priceManager.GetAll()    
                        );
                }

                return _items;
            }
        }
    }
}
