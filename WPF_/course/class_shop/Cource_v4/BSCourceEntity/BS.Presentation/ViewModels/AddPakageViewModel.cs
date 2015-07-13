using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.Business.Managers.Abstract;
using BS.Entity;
using BS.Presentation.Model;

namespace BS.Presentation.ViewModels
{
    class AddPakageViewModel
    {

        private readonly IPackageManager _packageManager;
        private readonly IProductManager _productManager;
        private readonly IProducerManager _producerManager;
        private readonly ICategoryManager _categoryManager;
        private readonly IMeasureManager _measureManager;
        private readonly IPriceManager _priceManager;

        #region Ctor

        public AddPakageViewModel(
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

        public string Name { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Producer { get; set; }
        public string Measure { get; set; }
        public decimal Volume { get; set; }
        public string VolMeasure { get; set; }
        public decimal? Price { get; set; }




    }
}


