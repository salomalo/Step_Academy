using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_UI
{
    
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           

            image3.Width = 20;

           
            BitmapImage myBitmapImage = new BitmapImage();

            
            myBitmapImage.BeginInit();
            string str = @"file://" + System.IO.Directory.GetCurrentDirectory() + "\\t.jpg";
            myBitmapImage.UriSource = new Uri(str);

           
            myBitmapImage.DecodePixelWidth = 20;
            myBitmapImage.EndInit();
            
            image3.Source = myBitmapImage;


        }
    }
}
