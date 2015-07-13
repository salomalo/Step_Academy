using System;
using System.Collections.Generic;
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

namespace Catalog.views.orders
{
    /// <summary>
    /// Логика взаимодействия для Add_Items.xaml
    /// </summary>
    public partial class Add_Items : UserControl
    {
        public Add_Items()
        {
            InitializeComponent();
        }

        private void lvDataBind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
