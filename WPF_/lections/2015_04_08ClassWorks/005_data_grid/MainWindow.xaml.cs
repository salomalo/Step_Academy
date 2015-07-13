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

namespace _005_data_grid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Employee> list = new List<Employee>();

            list.Add(new Employee { Id = 101, Name = "mike", Birthday = new DateTime(1981, 7, 23) });
            list.Add(new Employee { Id = 102, Name = "john", Birthday = new DateTime(1979, 6, 21) });
            list.Add(new Employee { Id = 103, Name = "todd", Birthday = new DateTime(1980, 3, 28) });
            list.Add(new Employee { Id = 104, Name = "marie", Birthday = new DateTime(1985, 2, 2) });
            list.Add(new Employee { Id = 105, Name = "bart", Birthday = new DateTime(1990, 11, 5) });

            dgEmployee.ItemsSource = list;
        }
    }

    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime Birthday { set; get; }

        public string EmployeeInfo {
            get {
                return Id + ": " + Name + " was born " + Birthday.ToShortDateString();
            }
        }
    }
}
