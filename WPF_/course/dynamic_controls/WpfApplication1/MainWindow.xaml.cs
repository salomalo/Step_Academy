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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button btnAdd = new Button
            {
                Width = 150,
                Height = 24,
                Name = "btnNew",
                Content = "My New Button",
                Margin = new Thickness(5, 5, 5, 5)
            };
            MainPanel.Children.Add(btnAdd);

            Button btnRemove = new Button
            {
                Width = 150,
                Height = 24,
                Content = "Remove New Button",
                Margin = new Thickness(5, 5, 5, 5)
            };
            btnRemove.Click += btnRemove_Click;
            MainPanel.Children.Add(btnRemove);



        }

        void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            // var btn = MainPanel.FindName("btnNew") as Button;

            var btn = FindChild<Button>(MainPanel, "btnNew");

            if (btn != null)
            {
                //MessageBox.Show("was found");
                MainPanel.Children.Remove(btn);
            }
            else
                MessageBox.Show("was NOT found");

        }
        
        
        public static T FindChild<T>(DependencyObject parent, string childName)
        where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child`s name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child`s name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }
    }


}
