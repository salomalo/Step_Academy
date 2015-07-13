using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _001_intro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnTimeConsumingWork_Click(object sender, RoutedEventArgs e)
        {
            btnPrintNumbers.IsEnabled = false;
            btnTimeConsumingWork.IsEnabled = false;

            // DoTimeConsumingWork();
            Thread newThread = new Thread(DoTimeConsumingWork);
            newThread.Start();

            btnPrintNumbers.IsEnabled = true;
            btnTimeConsumingWork.IsEnabled = true;
        }

        private void DoTimeConsumingWork()
        {
            Thread.Sleep(10000);
            MessageBox.Show("finish!!!");
        }

        private void btnPrintNumbers_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                lbxShowNumbers.Items.Add((i + 1));
            }
        }
    }
}
