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

namespace _004_wf_to_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (wfhDemo.Child as System.Windows.Forms.WebBrowser).Navigate("https://html5test.com/");
        }

        private void WebBrowser_DocumentTitleChanged(object sender, EventArgs e)
        {
            Title = (sender as System.Windows.Forms.WebBrowser).DocumentTitle;
        }
    }
}
