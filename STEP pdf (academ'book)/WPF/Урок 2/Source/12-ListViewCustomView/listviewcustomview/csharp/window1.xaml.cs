using System;
using System.Windows;
using System.Windows.Controls;

namespace SDKSample
{
   

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            ChangeView("GridView");
        }

        void SwitchViewMenu(object sender, RoutedEventArgs args)
        {
            MenuItem mi = (MenuItem)sender;
            ChangeView(mi.Header.ToString());
        }

        void ChangeView(string str)
        {
            if (str == "GridView")
            {
                lv.View = lv.FindResource("gridView") as ViewBase;
                currentView.Text = "GridView";
            }
            else if (str == "IconView")
            {
                lv.View = lv.FindResource("iconView") as ViewBase;
                currentView.Text = "IconView";
            }
            else if (str == "TileView")
            {
                
                lv.View = lv.FindResource("tileView") as ViewBase;
               
                currentView.Text = "TileView";
            }
            else if (str == "OneButtonHeaderView")
            {
                lv.View = lv.FindResource("OneButtonHeaderView") 
                     as ViewBase;
                currentView.Text = "OneButtonHeaderView";
            }
        }
    }
}