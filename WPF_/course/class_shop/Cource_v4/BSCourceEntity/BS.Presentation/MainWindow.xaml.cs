using BS.Business.Managers.Abstract;
using BS.Business.Managers.Concrete;
using BS.Entity;
using BS.Presentation.ViewModels;
using BS.Presentation.views.shop;
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


namespace BS.Presentation
{
    public partial class MainWindow : Window
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["BS_3VEntities"].ConnectionString;

        IPackageManager packageManager = new PackageManager(connectionString);
        IProductManager productManager = new ProductManager(connectionString);
        IProducerManager producerManager = new ProducerManager(connectionString);
        ICategoryManager categoryManager = new CategoryManager(connectionString);
        IMeasureManager measureManager = new MeasureManager(connectionString);
        IPriceManager priceManager = new PriceManager(connectionString);

        List<Categories> _categories = null;
        
        CatalogViewModel catalogViewModel;


        public addCategory newAddCat = new addCategory();
        public Add_packeg addpack = new Add_packeg();

        //public Catalog catalog = new Catalog();


        public MainWindow()
        {
            InitializeComponent();          
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                catalogViewModel = new CatalogViewModel(
                         packageManager
                        , productManager
                        , producerManager
                        , categoryManager
                        , measureManager
                        , priceManager
                    );
                views.shop.Catalog catalog = new views.shop.Catalog();

                catalog.lvDataBind.DataContext = catalogViewModel.Catalog;
                catalog.Name = "myCatalog";
                main.Children.Add(catalog);
                catalog.btnCatalogAdd.Click += btnCatalogAdd_Click;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCatalogAdd_Click(object sender, RoutedEventArgs e)
        {
            addpack.Name = "addPack";
            FindChild<UserControl>(main, "myCatalog").IsEnabled = false;
            addpack.btnAddPakageCancel.Click += btnAddPakageCancel_Click;


            addpack.cmbCat.ItemsSource = (from c in categoryManager.GetAll()
                                          where c.ParentId == null
                                          select c.Name).ToList();
            main.Children.Add(addpack);


          //  addpack.cmbSubCat.ItemsSource = (from c in categoryManager.GetAll()
                                            
                                                 // where (c.Name==


            addpack.btnAddCat.Click += btnAddCat_Click;
            addpack.btnEditCat.Click +=btnEditCat_Click;
        }

        private void btnEditCat_Click(object sender, RoutedEventArgs e)
        {
          //  addpack.cmbCat.Text 

            if (addpack.cmbCat.SelectedItem != null)
            {
                String name = ((addpack.cmbCat.SelectedItem) as Categories).Name;
                
               // String name = addpack.cmbCat.SelectedValue.ToString();
                MessageBox.Show(name);
                int tmp = (addpack.cmbCat.SelectedItem as Categories).Id;
                MessageBox.Show(tmp.ToString());


                //main.Children.Remove(FindChild<UserControl>(main, "addCat"));
                //FindChild<UserControl>(main, "addPack").IsEnabled = false;
                //main.Children.Add(newAddCat);
                //newAddCat.tbxName.Text = name;

                
               //int tmp = (addpack.cmbCat.SelectedItem as Categories).Id ;

               // categoryManager.Update((addpack.cmbCat.SelectedItem as Categories).Id, newAddCat.tbxName.Text);


            }
            
            

            ////////////////////////////

          //  categoryManager.Update();
        }


        public IEnumerable<Categories> Cat(Categories s)
        {
            if (_categories != null)
            {
                return categoryManager.GetAll().Where(c => c.ParentId == null);
            }
            return _categories;
        } // IEnumerable<Categories> Cat

        private void btnAddPakageCancel_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Remove(FindChild<UserControl>(main, "addPack"));
            FindChild<UserControl>(main, "myCatalog").IsEnabled = true;
        } // btnAddPakageCancel_Click

        private void btnAddCat_Click(object sender, RoutedEventArgs e)
        {
            main.Children.Remove(FindChild<UserControl>(main, "addCat"));
            FindChild<UserControl>(main, "addPack").IsEnabled = false;
            main.Children.Add(newAddCat);

            newAddCat.btnOk.Click += btnOkCat_Click;

        } // btnAddCat_Click


        private void btnOkCat_Click(object sender, RoutedEventArgs e)
        {
            if (newAddCat.tbxName.Text != "")
            {
                Categories newCat = new Categories()
                {
                    Name = newAddCat.tbxName.Text,
                    isActive = true
                };
                categoryManager.Insert(newCat);
            }
            else 
            {
                MessageBox.Show("add error here (validation)");
            }
  
        } // btnOkCat_Click



        // to find window's child 
        public static T FindChild<T>(DependencyObject parent, string childName)
        where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child`s name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child`s name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        } //  T : DependencyObject

    }
}
