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

namespace _002_listView
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

            items.Add(new User { Name = "mike smith", Age = 27, Email = "mike@gmail.com" });
            items.Add(new User { Name = "todd", Age = 31, Email = "tod@gmail.com" });
            items.Add(new User { Name = "john", Age = 35, Email = "john@gmail.com" });

            lvwDataBinding.ItemsSource = items;
        }
    }

    public class User
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public string Email { set; get; }


        public override string ToString()
        {
            return Name + "\t" + Age + "\t" + Email;
        }
    }
}
