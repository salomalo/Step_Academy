using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;

namespace _007_listView_and_databinding
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
            items.Add(new User { Name = "Mike", Age = 27, Email="mike_smith@gmail.com" });
            items.Add(new User { Name = "Todd", Age = 31, Email = "todd_johnes@gmail.com" });
            items.Add(new User { Name = "Hoze", Age = 35, Email = "hoze_rodrigues@gmail.com" });
            lvwDataBinding.ItemsSource = items;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Name + ", " + Age + " years old";
        }
    }
}
