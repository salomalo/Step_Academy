using BS.Business.Managers.Abstract;
using BS.Business.Managers.Concrete;
using BS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using BS.Presentation.Views;
using BS.Presentation.views.shop;
using BS.Presentation.Services;
using BS.Entity;
using System.Windows.Controls;
using BS.Presentation.views.warehouse;


namespace BS.Presentation
{
    public partial class MainWindow : Window
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["BS_3VEntities1"].ConnectionString;

        IPackageManager packageManager = new PackageManager(connectionString);
        IProductManager productManager = new ProductManager(connectionString);
        IProducerManager producerManager = new ProducerManager(connectionString);
        ICategoryManager categoryManager = new CategoryManager(connectionString);
        IMeasureManager measureManager = new MeasureManager(connectionString);
        IPriceManager priceManager = new PriceManager(connectionString);

        CatalogViewModel catalogViewModel;

        List<Categories> _categories = null;
        List<Producers> _producers = null;
        List<Products> _products = null;
        List<Measures> _measures = null;

        public bool editCategory;
        public views.shop.Catalog catalog;
        public Add_packeg addpack;



//////////////////           WAREHOUSES           ///////////////////////////////////////////////////////////////////
        IWarehouseManager wareHouseManager = new WarehouseManager(connectionString);
        IWarehouseItemManager wareHouseItem = new WarehouseItemManager(connectionString);      
        
        WarehouseViewModel warehouseViewModel; 

        List<WareHouses> _warehouses = null;
        List<WareHouseItems> _wareHouseItems = null;

        public views.warehouse.warehous _wareHouse;
//////////////////////////////////////////////////////////////////


        public MainWindow()
        {
            InitializeComponent();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

//////////////////           WAREHOUSES           ///////////////////////////////////////////////////////////////////
            try
            {
                warehouseViewModel = new WarehouseViewModel(
                        packageManager
                        , productManager
                        , producerManager
                        , wareHouseManager
                         , wareHouseItem
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
///////////////////////////////////////////////////////////////////

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnShowCatalog_Click(object sender, RoutedEventArgs e)
        {
            initialiserCatalog();
        }
        #region initialiser and Shower UIElements
        public void initialiserCatalog()
        {
            catalog = new views.shop.Catalog();
            catalog.lvDataBind.DataContext = catalogViewModel.Catalog;
            catalog.cmbCat.ItemsSource = Categories.Where(c => c.ParentId == null).OrderBy(c => c.Name);
            catalog.cmbCat.DisplayMemberPath = "Name";

            catalog.cmbCat.SelectedIndex = -1;
            catalog.cmbCat.SelectionChanged += (ss, ee) =>
            {
                if (catalog.cmbCat.SelectedItem != null)
                {
                    this.catalog.lvDataBind.DataContext =
                      catalogViewModel.Catalog.Where(c => c.SubCategory == (catalog.cmbCat.SelectedItem as Categories).Name);
                }
            };
            catalog.btnCatalogAdd.Click += (ss, ee) =>
            {
                initialiserAddPackage();
            };

            ContainerWindow catalogConteiner = new ContainerWindow();
            WindowHelper addcatalog = new WindowHelper(catalog, catalogConteiner, "Каталог товарів", main);
        }


//////////////////           WAREHOUSES           ///////////////////////////////////////////////////////////////////
        private void btnShowWareHouse_Click(object sender, RoutedEventArgs e)
        {
            initialiserWarehouse();
        }

        public void initialiserWarehouse()
        {
            _wareHouse = new views.warehouse.warehous();
            _wareHouse.lvDataBind.DataContext = warehouseViewModel.Warehouse;

            _wareHouse.cmbWh.DisplayMemberPath = "Adress";
            _wareHouse.cmbWh.ItemsSource = wareHouseManager.GetAll();

            ContainerWindow wareHouseConteiner = new ContainerWindow();
            WindowHelper addcatalog = new WindowHelper(_wareHouse, wareHouseConteiner, "Warhouses", main);


            _wareHouse.btnAddWH.Click += (ss, ee) =>
            {
                WarehItem warehItem = new WarehItem();
                ContainerWindow addwarehItemConteiner = new ContainerWindow();
                WindowHelper addwarehItemWindow = new WindowHelper(warehItem, addwarehItemConteiner, "Додати warehous", main);
                warehItem.btnSave.Click += (sss, eee) =>
           {
               bool result = true;

               foreach (var item in Warehouses)
               {
                   if (item.Adress == warehItem.tbAdress.Text)
                   {
                       result = false;
                   }

                   if (result)
                   {
                       if (warehItem.tbAdress.Text != null)
                       {
                           WareHouses newWareh = new WareHouses();
                           newWareh.Adress = warehItem.tbAdress.Text;
                           wareHouseManager.Insert(newWareh);
                           result = false;
                           addwarehItemWindow.CloseWindow(main, addwarehItemConteiner);
                       }
                       else
                       {
                           MessageBox.Show("Enter warehouses address!!!");
                       }
                   }
                   else
                   {
                       //MessageBox.Show("This warehouses already exists!!!");
                   }
               }
           };
                warehItem.btnCancel.Click += (sss, eee) => { addwarehItemWindow.CloseWindow(main, addwarehItemConteiner); };

            }; // _wareHouse.btnAddWH.Click


            _wareHouse.btnEditWh.Click += (ss, ee) =>
                {
                    WarehItem warehItem = new WarehItem();
                    ContainerWindow editwarehItemConteiner = new ContainerWindow();
                    WindowHelper editwarehItemWindow = new WindowHelper(warehItem, editwarehItemConteiner, "EDIT warehous", main);

                    warehItem.tbAdress.Text = (_wareHouse.cmbWh.SelectedItem as WareHouses).Adress;
                    warehItem.btnSave.Click += (sss, eee) =>
                        {
                            wareHouseManager.Update((_wareHouse.cmbWh.SelectedItem as WareHouses).Id,warehItem.tbAdress.Text);
                            editwarehItemWindow.CloseWindow(main, editwarehItemConteiner);
                        }; // warehItem.btnSave.Click

                    warehItem.btnCancel.Click += (sss, eee) => { editwarehItemWindow.CloseWindow(main, editwarehItemConteiner); };

                }; // _wareHouse.btnEditWh.Click 
            




            _wareHouse.btnSearch.Click += (s, e) =>
                {
                    //_wareHouse.tbSearch.Text;

                }; // _wareHouse.btnSearch.Click




            _wareHouse.cmbWh.SelectionChanged += (s, e) =>
                {
                    if (_wareHouse.cmbWh.SelectedItem != null)
                    {
                        this._wareHouse.lvDataBind.DataContext =
                            warehouseViewModel.Warehouse.Where(c => c.Adress == (_wareHouse.cmbWh.SelectedItem as WareHouses).Adress);
                    }
                };//_wareHouse.cmbWh.SelectionChanged

  
        } //  initialiserWarehouse()



        public IEnumerable<WareHouses> Warehouses
        {
            get
            {
                if (_warehouses == null)
                {
                    return wareHouseManager.GetAll().ToList();
                }
                return _warehouses;
            }
        }
        public IEnumerable<WareHouseItems> WareHouseItems
        {
            get
            {
                if (_wareHouseItems == null)
                {
                    return wareHouseItem.GetAll().ToList();
                }
                return _wareHouseItems;
            }
        }


//////////////////////////////////////////////////////////////////////////////////////////////////////////////




        public void initialiserAddPackage()
        {
            addpack = new Add_packeg();
            addpack.cmbCat.ItemsSource = Categories.Where(c => c.ParentId == null).OrderBy(c => c.Name);
            addpack.cmbCat.DisplayMemberPath = "Name";
            addpack.cmbVolumeMeasure.ItemsSource = Measures.OrderBy(c => c.Name);
            addpack.cmbVolumeMeasure.DisplayMemberPath = "Name";
            addpack.cmbMeasure.ItemsSource = Measures.OrderBy(c => c.Name);
            addpack.cmbMeasure.DisplayMemberPath = "Name";
            ContainerWindow addpackConteiner = new ContainerWindow();
            WindowHelper addpackWindow = new WindowHelper(addpack, addpackConteiner, "Додати товар", main);

            #region ComboBoxes
            addpack.cmbCat.SelectionChanged += (ss, ee) =>
            {
                try
                {
                    if (addpack.cmbCat.SelectedItem != null)
                    {
                        addpack.cmbSubCat.ItemsSource = Categories.Where(c => c.ParentId == (addpack.cmbCat.SelectedItem as Categories).Id)
                       .OrderBy(c => c.Name);
                        addpack.cmbSubCat.DisplayMemberPath = "Name";
                    }
                    addpack.cmbSubCat.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    addpack.cmbSubCat.DataContext = null;
                }
            };

            addpack.cmbSubCat.SelectionChanged += (ss, ee) =>
            {
                try
                {
                    if (addpack.cmbSubCat.SelectedItem != null)
                    {
                        addpack.cmbName.ItemsSource = Products.Where(c => c.CategoryId == (addpack.cmbSubCat.SelectedItem as Categories).Id)
                       .OrderBy(c => c.Name);
                        addpack.cmbName.DisplayMemberPath = "Name";
                    }
                    addpack.cmbName.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    addpack.cmbName.DataContext = null;
                }
            };

            addpack.cmbName.SelectionChanged += (ss, ee) =>
            {
                try
                {
                    if (addpack.cmbName.SelectedItem != null)
                    {
                        addpack.cmbProduc.ItemsSource = Producers.Where(c => c.Id == (addpack.cmbName.SelectedItem as Products).ProducerId)
                       .OrderBy(c => c.Name);
                        addpack.cmbProduc.DisplayMemberPath = "Name";
                    }
                    addpack.cmbProduc.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    addpack.cmbProduc.DataContext = null;
                }
            };
            #endregion

            addpack.btnAddPakageCancel.Click += (ss, ee) => { addpackWindow.CloseWindow(main, addpackConteiner); };

            #region Button Save
            addpack.btnAddPakageSave.Click += (ss, ee) =>
            {
                if (addpack.cmbName.SelectedItem != null && addpack.cmbCat.SelectedItem != null && addpack.cmbSubCat.SelectedItem != null && addpack.cmbProduc.SelectedItem != null &&
                    addpack.cmbVolumeMeasure.SelectedItem != null && addpack.cmbMeasure.SelectedItem != null && addpack.tbVolume.Text != null && addpack.tbPrice.Text != null)
                {
                    Packages newPack = new Packages();
                    newPack.ProductId = (addpack.cmbName.SelectedItem as Products).Id;
                    newPack.Volume = Convert.ToDecimal(addpack.tbVolume.Text);
                    newPack.VolumeMeasureId = (addpack.cmbVolumeMeasure.SelectedItem as Measures).Id;
                    newPack.MeasureId = (addpack.cmbMeasure.SelectedItem as Measures).Id;
                    int Id = packageManager.Insert(newPack);
                    Prices newPrice = new Prices();
                    newPrice.PackageId = newPack.Id;
                    newPrice.PriceTime = DateTime.Now;
                    newPrice.UnitCost = Convert.ToDecimal(addpack.tbPrice.Text);
                    priceManager.Insert(newPrice);
                    addpackWindow.CloseWindow(main, addpackConteiner);
                    catalogViewModel = new CatalogViewModel(packageManager
                        , productManager
                        , producerManager
                        , categoryManager
                        , measureManager
                        , priceManager);
                    catalog.lvDataBind.DataContext = catalogViewModel.Catalog;
                    catalog.cmbCat.SelectedIndex = -1;

                }
                else
                {
                    MessageBox.Show("Не всі поля заповнені");
                }

            };
            #endregion

            #region Button Add Category
            addpack.btnAddCat.Click += (ss, ee) =>
            {

                Category addCat = new Category();
                ContainerWindow addCatConteiner = new ContainerWindow();
                WindowHelper addCatWindow = new WindowHelper(addCat, addCatConteiner, "Додати категорію", main);

                addCat.tbSubCat.IsEnabled = false;
                addCat.btnSave.Click += (sss, eee) =>
                {

                    bool result = true;

                    foreach (var item in Categories)
                    {
                        if (item.Name == addCat.tbCat.Text && item.ParentId == null)
                        {
                            result = false;
                        }
                    }
                    if (result)
                    {
                        if (addCat.tbCat.Text != null)
                        {
                            Categories newCat = new Categories();
                            newCat.ParentId = null;
                            newCat.Name = addCat.tbCat.Text;
                            categoryManager.Insert(newCat);
                            result = false;
                            addCatWindow.CloseWindow(main, addCatConteiner);
                        }
                        else
                        {
                            MessageBox.Show("Enter category name!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("This category already exists!!!");
                    }
                };
                addCat.btnCancel.Click += (sss, eee) => { addCatWindow.CloseWindow(main, addCatConteiner); };

            };
            #endregion


            //addpack.btnEditCat.Click += (ss, ee) =>
            //    {
            //        if (addpack.cmbCat.SelectedItem != null)
            //        {
            //            Category addCat = new Category();
            //            ContainerWindow addCatConteiner = new ContainerWindow();
            //            WindowHelper addCatWindow = new WindowHelper(addCat, addCatConteiner, "EDIT категорію", main);
            //            addCat.tbCat.IsEnabled = false;

            //            addCat.tbCat.Text = (addpack.cmbCat.SelectedItem as Categories).Name;

            //            addCat.btnCancel.Click += (sss, eee) => { addCatWindow.CloseWindow(main, addCatConteiner); };
            //            addCat.btnSave.Click += (sss, eee) =>
            //            {
            //                MessageBox.Show((addpack.cmbCat.SelectedItem as Categories).Id.ToString());
            //            };
            //        }

            //    };



            #region Button Add SubCategory
            addpack.btnAddSubCat.Click += (ss, ee) =>
            {
                if (addpack.cmbCat.SelectedItem != null)
                {
                    Category addCat = new Category();
                    ContainerWindow addCatConteiner = new ContainerWindow();
                    WindowHelper addCatWindow = new WindowHelper(addCat, addCatConteiner, "Додати категорію", main);

                    addCat.tbCat.IsEnabled = false;

                    addCat.tbCat.Text = (addpack.cmbCat.SelectedItem as Categories).Name;

                    addCat.btnCancel.Click += (sss, eee) => { addCatWindow.CloseWindow(main, addCatConteiner); };
                    addCat.btnSave.Click += (sss, eee) =>
                    {

                        bool result = true;

                        foreach (var item in Categories)
                        {
                            if (item.Name == addCat.tbSubCat.Text && item.ParentId == (addpack.cmbCat.SelectedItem as Categories).Id)
                            {
                                result = false;
                            }
                        }
                        if (result)
                        {
                            if (addCat.tbSubCat.Text != null)
                            {
                                Categories newCat = new Categories();
                                newCat.ParentId = (addpack.cmbCat.SelectedItem as Categories).Id;
                                newCat.Name = addCat.tbSubCat.Text;
                                categoryManager.Insert(newCat);
                                result = false;
                                addCatWindow.CloseWindow(main, addCatConteiner);
                            }
                            else
                            {
                                MessageBox.Show("Enter subcategory name!!!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("This category already exists!!!");
                        }
                    };
                }
                else
                {
                    MessageBox.Show("The main category does not select!!!");
                }
            };
            #endregion

            #region Button Add Product(Name)
            addpack.btnAddName.Click += (ss, ee) =>
            {
                if (addpack.cmbSubCat.SelectedItem != null)
                {
                    Views.shop.Add_Product addproduct = new Views.shop.Add_Product();
                    ContainerWindow addNameConteiner = new ContainerWindow();
                    WindowHelper addNameWindow = new WindowHelper(addproduct, addNameConteiner, "Додати продукт", main);
                    addproduct.btnAddProductCancel.Click += (sss, eee) => { addNameWindow.CloseWindow(main, addNameConteiner); };
                    addproduct.tbCategory.Text = (addpack.cmbSubCat.SelectedItem as Categories).Name;
                    addproduct.cmbProducer.ItemsSource = Producers.OrderBy(c => c.Name);
                    addproduct.cmbProducer.DisplayMemberPath = "Name";
                    addproduct.cmbProducer.SelectedIndex = 0;

                    #region Button Save Product(Name)

                    addproduct.btnAddProductSave.Click += (sss, eee) =>
                    {
                        if (addproduct.tbName.Text != null)
                        {
                            bool result = true;

                            foreach (var item in Products)
                            {
                                if (item.Name == addproduct.tbName.Text)
                                {
                                    result = false;
                                }
                            }
                            if (result)
                            {
                                Products newProd = new Products();
                                newProd.CategoryId = (addpack.cmbSubCat.SelectedItem as Categories).Id;
                                newProd.Name = addproduct.tbName.Text;
                                newProd.ProducerId = (addproduct.cmbProducer.SelectedItem as Producers).Id;
                                productManager.Insert(newProd);
                                addNameWindow.CloseWindow(main, addNameConteiner);
                                result = false;
                            }
                            else
                            {
                                MessageBox.Show("The product is already exists!!!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Enter Product name!!!");
                        }

                    };
                    #endregion

                    #region Button Add Produser
                    addproduct.btnAddProducer.Click += (sss, eee) =>
                    {


                        add_producer addproduser = new add_producer();
                        ContainerWindow addproduserConteiner = new ContainerWindow();
                        WindowHelper addproduserWindow = new WindowHelper(addproduser, addproduserConteiner, "Додати виробника", main);
                        addproduser.btnCancel.Click += (ssss, eeee) => { addproduserWindow.CloseWindow(main, addproduserConteiner); };
                        addproduser.btnSave.Click += (ssss, eeee) =>
                        {
                            if (addproduser.tbAdress.Text != null && addproduser.tbName.Text != null && addproduser.tbTel.Text != null)
                            {
                                bool result = true;

                                foreach (var item in Producers)
                                {
                                    if (item.Name == addproduser.tbName.Text)
                                    {
                                        result = false;
                                    }
                                }
                                if (result)
                                {

                                    Producers newproduser = new Producers();
                                    newproduser.Name = addproduser.tbName.Text;
                                    newproduser.Adress = addproduser.tbAdress.Text;
                                    newproduser.Phone = addproduser.tbTel.Text;
                                    producerManager.Insert(newproduser);
                                    result = false;
                                    addproduserWindow.CloseWindow(main, addproduserConteiner);

                                }
                                else
                                {
                                    MessageBox.Show("The protuser already exists!!!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Enter all datas!!!");
                            }


                        };



                    #endregion


                    };

                };






            };
            #endregion

        }
        public void initialiserEditCategory()
        {

        }
        #endregion
        public IEnumerable<Categories> RefreshMain()
        {
            return categoryManager.GetAll().ToList().Where(c => c.ParentId == null)
                   .OrderBy(c => c.Name);
        }
        #region Control Properties

        public IEnumerable<Categories> Categories
        {
            get
            {
                if (_categories == null)
                {
                    return categoryManager.GetAll().ToList();
                }
                return _categories;
            }
        }
        public IEnumerable<Measures> Measures
        {
            get
            {
                if (_measures == null)
                {
                    return measureManager.GetAll().ToList();
                }
                return _measures;
            }
        }
        public IEnumerable<Producers> Producers
        {
            get
            {
                if (_producers == null)
                {
                    return producerManager.GetAll().ToList();
                }
                return _producers;
            }
        }
        public IEnumerable<Products> Products
        {
            get
            {
                if (_products == null)
                {
                    return productManager.GetAll().ToList();
                }
                return _products;
            }
        }


        #endregion




    } // MainWindow : Window
}