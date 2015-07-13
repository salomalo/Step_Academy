using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace _011_ListViewFiltering
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
            items.Add(new User { Name = "Mike", Age = 27, Email = "exxxeh@gmail.com" });
            items.Add(new User { Name = "Todd", Age = 31, Email = "todd_johnes@gmail.com" });
            items.Add(new User { Name = "Marie", Age = 30, Email = "marie_siemens@gmail.com" });
            items.Add(new User { Name = "Hoze", Age = 35, Email = "hoze_rodrigues@gmail.com" });
            lvwUsers.ItemsSource = items;

            CollectionView cv = CollectionViewSource.GetDefaultView(lvwUsers.ItemsSource) as CollectionView;
            cv.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
            {
                return true;
            }
            else
            { 
                return (
                    (item as User).Email.IndexOf(txtFilter.Text, StringComparison.CurrentCultureIgnoreCase) >= 0 ||
                    (item as User).Name.IndexOf(txtFilter.Text, StringComparison.CurrentCultureIgnoreCase) >= 0);
            }
        }
        
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvwUsers.ItemsSource).Refresh();
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

}
