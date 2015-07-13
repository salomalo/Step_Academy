using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;

namespace _008_listView_grouping
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
            items.Add(new User { Name = "Mike", Age = 27, Email = "mike_smith@gmail.com",       Gender = "1" });
            items.Add(new User { Name = "Marie", Age = 31, Email = "marie_siemens@gmail.com",   Gender = "1" });
            items.Add(new User { Name = "todd", Age = 35, Email = "todd_johnes@gmail.com",      Gender = "2" });
            items.Add(new User { Name = "rita", Age = 36, Email = "rita@gmail.com",             Gender = "2" });
            items.Add(new User { Name = "crazy", Age = 18, Email = "crazy@gmail.com",           Gender = "3" });
            lvwUsers.ItemsSource = items;

            CollectionView cv =
                CollectionViewSource.GetDefaultView(lvwUsers.ItemsSource) as CollectionView;
            PropertyGroupDescription gd = new PropertyGroupDescription("Gender");
            cv.GroupDescriptions.Add(gd);
        }
    }

    // public enum GenderType { Male, Female, HowKnow };


    public class User
    {
        public static List<string> GenderType = new List<string> { 
            "man", "woman", "how Knows"
        };


        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Gender { set; get; }

        public override string ToString()
        {
            return Name + ", " + Age + " years old";
        }
    }
}
