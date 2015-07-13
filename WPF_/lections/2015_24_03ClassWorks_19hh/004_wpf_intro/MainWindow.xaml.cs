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

namespace _004_wpf_intro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button btn = new Button();
            btn.FontWeight = FontWeights.Bold;

            WrapPanel wpn1 = new WrapPanel();

            TextBlock tbl = new TextBlock();
            tbl.Text = "Multi";
            tbl.Foreground = Brushes.Red;
            wpn1.Children.Add(tbl);

            tbl = new TextBlock();
            tbl.Text = "Color";
            tbl.Foreground = Brushes.Green;
            wpn1.Children.Add(tbl);

            tbl = new TextBlock();
            tbl.Text = "Button";
            tbl.Foreground = Brushes.Blue;
            wpn1.Children.Add(tbl);

            btn.Content = wpn1;

            btn.Click += new RoutedEventHandler(btn_Click);

            pnlMain.Children.Add(btn);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
                MessageBox.Show("Button Clicked!");
        }



        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Hello WPF!");
        }
    }
}
