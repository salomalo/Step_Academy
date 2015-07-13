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

namespace _003_TextBlock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TextBlock txbl = new TextBlock();
            txbl.TextWrapping = TextWrapping.Wrap;
            txbl.Margin = new Thickness(10);

            txbl.Inlines.Add("An example on ");
            txbl.Inlines.Add(new Run("the TextBlock control ") { FontWeight = FontWeights.Bold });
            txbl.Inlines.Add("using ");
            txbl.Inlines.Add(new Run("inline ") { FontStyle = FontStyles.Italic });

            // this.Content = txbl;
            pnlMain.Children.Add(txbl);

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
