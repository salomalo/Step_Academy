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

namespace _005_ToolBar
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

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int row = tbxEditor.GetLineIndexFromCharacterIndex(tbxEditor.CaretIndex);
            int col = tbxEditor.CaretIndex - tbxEditor.GetCharacterIndexFromLineIndex(row);

            // tblCursorPosition.Text = tbxEditor.CaretIndex.ToString() + " " + tbxEditor.GetCharacterIndexFromLineIndex(row) + " " + row;
            tblCursorPosition.Text = "Line: " + (row + 1) + ", Char: " + (col + 1);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // if(sender as ComboBox).Sel != null)
            MessageBox.Show((cbx.SelectedItem as ComboBoxItem).Content.ToString());
        }
    }
}
