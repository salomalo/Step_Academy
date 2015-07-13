using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace _004_Crud
{
    class User : INotifyPropertyChanged
    {
        string _name;

        public string Name 
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
    
    public partial class MainWindow : Window
    {
        // List<User> _users = new List<User>();
        ObservableCollection<User> _users = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();

            _users.Add(new User { Name = "Bill Gates" });
            _users.Add(new User { Name = "Hoze Rodrigues" });

            lbxUsers.ItemsSource = _users;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            _users.Add(new User { Name = "New User" });
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (lbxUsers.SelectedItem != null)
            {
                (lbxUsers.SelectedItem as User).Name = "Random Name";
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lbxUsers.SelectedItem != null)
            {
                _users.Remove(lbxUsers.SelectedItem as User);
            }
        }
    }
}
