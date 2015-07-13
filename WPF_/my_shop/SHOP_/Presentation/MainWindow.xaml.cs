using Business.Managers.Abstract;
using Business.Managers.Concrete;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["testEntities"].ConnectionString;

                IPackageManager packageManager = new PackageManager(connectionString);
                IProductManager productManager = new ProductManager(connectionString);
                IProducerManager producerManager = new ProducerManager(connectionString);
                ICategoryManager categoryManager = new CategoryManager(connectionString);
                IMeasureManager measureManager = new MeasureManager(connectionString);
                IPriceManager priceManager = new PriceManager(connectionString);

                CatalogViewModel catalogViewModel = new CatalogViewModel(
                         packageManager
                        , productManager
                        , producerManager
                        , categoryManager
                        , measureManager
                        , priceManager
                    );

                vwCatalog.dgCatalogUC.DataContext = catalogViewModel.Catalog;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
