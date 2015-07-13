using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace _001_StringFormat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // List<string> res = new List<string>();
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                string sName = String.Empty;
                sName = CultureInfo.CreateSpecificCulture(ci.Name).Name;

                tbxCulturesNames.Text += String.Format("{0,-10} - {1,-10} : {2, -10} , {3}",
                    ci.Name, sName, ci.EnglishName, ci.NativeName
                    );
                tbxCulturesNames.Text += Environment.NewLine;
            }

        }
    }
}
