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
using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Process myPr;

        public MainWindow()
        {
            InitializeComponent();
            
            myPr = new Process();
            myPr.StartInfo = new System.Diagnostics.ProcessStartInfo("calc.exe");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myPr.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //if(myPr.e
            myPr.CloseMainWindow();
            myPr.Close();
        }


    }
}
