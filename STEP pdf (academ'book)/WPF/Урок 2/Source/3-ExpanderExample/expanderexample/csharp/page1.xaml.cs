using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpanderDirectionExample
{
   
    public partial class Page1 : Page
    {
        private void ChangeExpandDirection(object sender, RoutedEventArgs e)
        {
            if ((Boolean)ExpandDown.IsChecked)
                myExpander.ExpandDirection = ExpandDirection.Down;
            else if ((Boolean)ExpandUp.IsChecked)
                myExpander.ExpandDirection = ExpandDirection.Up;
            else if ((Boolean)ExpandLeft.IsChecked)
                myExpander.ExpandDirection = ExpandDirection.Left;
            else if ((Boolean)ExpandRight.IsChecked)
                myExpander.ExpandDirection = ExpandDirection.Right;

           
            myExpander.IsExpanded = true;
        }
        
    }
}