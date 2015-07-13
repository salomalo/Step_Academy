using System;
using System.Collections.Generic;
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

namespace _003_big_example_binding
{
    public partial class MainWindow : Window
    {
        private List<Employee> _employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted); 
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _employees = DataSupplier.GetEmployee();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbxEmployees.ItemsSource = _employees;
            LoadingGrid.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btnNewName_Click(object sender, RoutedEventArgs e)
        {
            if (lbxEmployees.SelectedItem != null)
            {
                (lbxEmployees.SelectedItem as Employee).Name = tbxNewName.Text;
            }
        }
    }
}
