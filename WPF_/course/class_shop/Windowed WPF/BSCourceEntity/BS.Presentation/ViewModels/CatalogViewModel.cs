using BS.Business.Managers.Abstract;
using BS.Entity;
using BS.Presentation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Presentation.ViewModels
{
    public class CatalogViewModel
    {
        private readonly IPackageManager  _packageManager;
        private readonly IProductManager  _productManager;
        private readonly IProducerManager _producerManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IMeasureManager  _measureManager;
        private readonly IPriceManager    _priceManager;

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
             IEnumerable<Packages> pPackages
            , IEnumerable<Products> pProducts
            , IEnumerable<Producers> pProducers
            , IEnumerable<Categories> cCategories
            , IEnumerable<Measures> mMeasures
            , IEnumerable<Prices> pPrices
            )
        {
            List<CatalogModel> listCM = new List<CatalogModel>();

            //Query Like (Sql like)
            var resCatalog =
                //Packages      
                      from pack in pPackages
                      //Price
                      join priceT in pPrices
                        on pack.Id equals priceT.PackageId into prices
                      from price in prices.DefaultIfEmpty()
                      //щоб вибрати останню ціну
                      join temp in
                          (from tmpPrice in pPrices
                           join sub in
                               (from pp in pPrices
                                group pp by new { pp.PackageId } into prices
                                select new
                                {
                                    Pack = prices.Key.PackageId,
                                    Time = (from t in prices select t.PriceTime).Max()
                                })
                            on tmpPrice.PackageId equals sub.Pack
                           where tmpPrice.PackageId == sub.Pack && tmpPrice.PriceTime == sub.Time
                           select new
                          {
                              tmpPrice.Id
                          })
                      on price.Id equals temp.Id
                      //Products
                      join product in pProducts
                        on pack.ProductId equals product.Id into products
                      from prod in products.DefaultIfEmpty()
                      //Categories
                      join category in cCategories
                        on prod.CategoryId equals category.Id into categories
                      from cat in categories.DefaultIfEmpty()
                      //SubCategories
                      join subCategory in cCategories
                        on cat.ParentId equals subCategory.Id into subCategories
                      from subCat in subCategories.DefaultIfEmpty()
                      //Producers
                      join producer in pProducers
                        on prod.ProducerId equals producer.Id into producers
                      from prodc in producers.DefaultIfEmpty()
                      //PackageMeasures
                      join measure in mMeasures
                        on pack.MeasureId equals measure.Id into measures
                      from m in measures.DefaultIfEmpty()
                      //VolumeMeasures
                      join measureVol in mMeasures
                        on pack.VolumeMeasureId equals measureVol.Id into measuresVol
                      from mV in measuresVol.DefaultIfEmpty()
                      orderby pack.Id

                      select new
                      {
                          Id = pack.Id,
                          Name = prod.Name,
                          Producer = prodc.Name,
                          Category = cat.Name,
                          SubCategory = subCat.Name,
                          Volume = pack.Volume,
                          VolMeasure = mV.ShortName,
                          Measure = m.ShortName,
                          Price = price.UnitCost
                      };


            foreach (var c in resCatalog)
            {
                listCM.Add(
                        new CatalogModel(
                             c.Id
                            , c.Name
                            , c.Category
                            , c.SubCategory
                            , c.Producer
                            , c.Measure
                            , c.Volume
                            , c.VolMeasure                            
                            , c.Price
                            )
                    );
            }

            return listCM;
        } // static public List<CatalogModel> CreateCatalogModel

        public IEnumerable<CatalogModel> Catalog
        {
            get
            {
                if (_items == null)
                {
                    _items = CreateCatalogModel(
                        _packageManager.GetAll(),
                        _productManager.GetAll(),
                        _producerManager.GetAll(),
                        _categoryManager.GetAll(),
                        _measureManager.GetAll(),
                        _priceManager.GetAll()
                        );
                }

                return _items;
            }
        }
    }
}
