using Entities;
using Business.Managers.Abstract;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels
{
    class CatalogViewModel
    {
        private readonly IPackageManager _packageManager;
        private readonly IProductManager _productManager;
        private readonly IProducerManager _producerManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IMeasureManager _measureManager;
        private readonly IPriceManager _priceManager;

        private List<CatalogModel> _items = null;

        #region Ctor

        public CatalogViewModel(
             IPackageManager packageManager
            , IProductManager productManager
            , IProducerManager producerManager
            , ICategoryManager categoryManager
            , IMeasureManager measureManager
            , IPriceManager priceManager
            )
        {
            _packageManager = packageManager;
            _productManager = productManager;
            _producerManager = producerManager;
            _categoryManager = categoryManager;
            _measureManager = measureManager;
            _priceManager = priceManager;
        }

        #endregion

        static public List<CatalogModel> CreateCatalogModel(
                 IEnumerable<Packeges> packages
                , IEnumerable<Products> products
                , IEnumerable<Producers> producers
                , IEnumerable<Categorys> categories
                , IEnumerable<Measures> measures
                , IEnumerable<Prices> prices
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
                    on pg.Id equals m.Id
                join vm in measures
                    on pg.Id equals vm.Id
                join pr in prices
                    on pg.Id equals pr.Id
                select new
                {
                    Id = pg.Id
                    ,
                    Name = p.Name
                    ,
                    Producer = prd.Name
                    ,
                    Category = c.Name
                    ,
                    SubCategory = cc.Name
                    ,
                    Volume = pg.Volume
                    ,
                    VolMeasure = vm.SmallName
                    ,
                    Measure = m.SmallName
                    ,
                    Price = pr.UnitCost
                };

            foreach (var c in res)
            {
                listCM.Add(
                        new CatalogModel(
                             c.Id
                            , c.Name
                            , c.Producer
                            , c.Category
                            , c.SubCategory
                            , c.Volume
                            , c.VolMeasure
                            , c.Measure
                           , c.Price)
                    );
            }

            return listCM;
        }

        public IEnumerable<CatalogModel> Catalog
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateCatalogModel(
                             _packageManager.GetAll()
                            , _productManager.GetAll()
                            , _producerManager.GetAll()
                            , _categoryManager.GetAll()
                            , _measureManager.GetAll()
                            , _priceManager.GetAll()
                        );
                }

                return _items;
            }
        }
    }
}
