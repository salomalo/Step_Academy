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

namespace _002_cut_paste_demo
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var res = (from a in AppDomain.CurrentDomain.GetAssemblies()
                      from t in a.GetTypes()
                      from p in t.GetProperties()
                      where typeof(ICommand).IsAssignableFrom(p.PropertyType) &&
                      p.GetAccessors()[0].IsStatic
                      orderby t.Name, p.Name
                      select t.Name + " " + p.Name).ToList();

            foreach (var c in res)
            {
                tbxEditor.Text += c;
                tbxEditor.Text += Environment.NewLine;
            }
        }

        //private void CutCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = tbxEditor != null && tbxEditor.SelectionLength > 0;
        //}

        //private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    tbxEditor.Cut();
        //}

        //private void PasteCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = Clipboard.ContainsText();
        //}

        //private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    tbxEditor.Paste();
        //}
    }
}
