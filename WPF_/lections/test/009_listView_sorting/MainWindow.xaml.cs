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

namespace _009_listView_sorting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<User> items = new List<User>();
            items.Add(new User { Name = "Todd", Age = 31, Email = "todd_johnes@gmail.com" });
            items.Add(new User { Name = "Marie", Age = 30, Email = "marie_siemens@gmail.com" });
            items.Add(new User { Name = "Mike", Age = 27, Email = "mike_smith@gmail.com" });
            items.Add(new User { Name = "Hoze", Age = 35, Email = "hoze_rodrigues@gmail.com" });
            lvwUsers.ItemsSource = items;

            CollectionView cv = CollectionViewSource.GetDefaultView(lvwUsers.ItemsSource) as CollectionView;
            cv.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
            cv.SortDescriptions.Add(new System.ComponentModel.SortDescription("Age", System.ComponentModel.ListSortDirection.Ascending));
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
