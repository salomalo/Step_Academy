using BS.Business.Managers.Abstract;
using BS.Business.Managers.Concrete;
using BS.Entities;
using BS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using BS.Business.Managers.Linq;
using BS.Business.Managers.XML;

namespace BS.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string _cs = ConfigurationManager.ConnectionStrings["testEntities"].ConnectionString;

        IPackageManager _packageManager = new PackageManager(_cs);
        IProductManager _productManager = new ProductManager(_cs);
        IProducerManager _producerManager = new ProducerManager(_cs);
        ICategoryManager _categoryManager = new LinqCategoryManager();
        //ICategoryManager _categoryManager = new CategoryManager(_cs);
        IMeasureManager _measureManager = new XMLMeasureManager();
        //IMeasureManager _measureManager = new MeasureManager(_cs);
        IPriceManager _priceManager = new PriceManager(_cs);

        CatalogViewModel _catalogViewModel;

        List<Category> _categories = null;
        
        public MainWindow()
        {
            InitializeComponent();

            _catalogViewModel = new CatalogViewModel(
                 _packageManager
                , _productManager
                , _producerManager
                , _categoryManager
                , _measureManager
                , _priceManager
            );

            vwCatalog.cmbCategory.SelectedIndex = 0;
            vwCatalog.cmbCategory.SelectionChanged += cmbCategory_SelectionChanged;
        }

        void cmbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vwCatalog.dgCatalogUC.DataContext =
                 _catalogViewModel.Catalog.Where(c => c.SubCategory == (vwCatalog.cmbCategory.SelectedItem as Category).Name);

        }

        #region Control Properties

        public IEnumerable<Category> Categories
        {
            get {
                if (_categories == null)
                {
                    return _categoryManager.GetAll().ToList();
                }
                return _categories;
            }
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                vwCatalog.cmbCategory.DataContext =
                    Categories.Where(c => c.ParentId == null)
                    .OrderBy(c => c.Name)
                    //.Select(c => c.Name)
                    ;


                vwCatalog.dgCatalogUC.DataContext = _catalogViewModel.Catalog;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
