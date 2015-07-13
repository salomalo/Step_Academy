using System;
using System.Collections.Generic;
using System.IO;
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

namespace _004_dist_info
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var drives = DriveInfo.GetDrives();

            foreach (var di in drives)
            {
                tvDiskInfo.Items.Add(CreateTreeItem(di));
            }
        }

        private TreeViewItem CreateTreeItem(object obj)
        {
            TreeViewItem item = new TreeViewItem { Header = obj.ToString(), Tag = obj };
            item.Items.Add("Loading...");

            return item;
        }
        
        private void tvDiskInfo_Expanded(object sender, RoutedEventArgs e)
        {
            var item = e.Source as TreeViewItem;

            if (item.Items[0] is string)
            {
                item.Items.Clear();

                DirectoryInfo exp = null;

                if (item.Tag is DriveInfo)
                {
                    exp = (item.Tag as DriveInfo).RootDirectory;
                }

                if (item.Tag is DirectoryInfo)
                {
                    exp = item.Tag as DirectoryInfo;
                }

                try
                {
                    foreach (var sub in exp.GetDirectories())
                    {
                        item.Items.Add(CreateTreeItem(sub));
                    }
                }
                catch { }
            }
        }
    }
}
