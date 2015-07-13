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

namespace _002_treeview_databinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            myTreeViewItem root = new myTreeViewItem { Title = "Root" };
            
            myTreeViewItem childItem1 = new myTreeViewItem { Title = "Child Item 1" };

            childItem1.Items.Add(new myTreeViewItem { Title = "Child Item 1.1" });
            childItem1.Items.Add(new myTreeViewItem { Title = "Child Item 1.2" });
            childItem1.Items.Add(new myTreeViewItem { Title = "Child Item 1.3" });

            root.Items.Add(childItem1);

            root.Items.Add(new myTreeViewItem { Title = "Child Item 2" });

            tvDemo.Items.Add(root);
        }
    }

    public class myTreeViewItem
    {
        public List<myTreeViewItem> Items { set; get; }
        public string Title { set; get; }

        public myTreeViewItem()
        {
            Items = new List<myTreeViewItem>();
        }
    }
}
