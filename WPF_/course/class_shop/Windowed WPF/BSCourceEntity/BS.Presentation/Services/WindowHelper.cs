using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.Presentation.Views;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BS.Presentation.Services
{
    class WindowHelper
    {

        public WindowHelper(UserControl userControl, ContainerWindow mw, string windowTitle, Canvas main)
        { 
        CreateWindow(userControl, mw, windowTitle, main);
        }



      public void CreateWindow(UserControl userControl, ContainerWindow mw, string windowTitle, Canvas main)
       {

           mw.Margin = new Thickness(100, 60, 0, 0);
           mw.Name = userControl.GetType().Name;
           mw.Lable.Text = windowTitle;
           mw.windowheader.MouseDown += (s, eVent) =>
           {
               bool isHeader = true;

               Mouse.Capture(mw);
               Point InitMousePos = eVent.GetPosition(main);

               mw.MouseMove += (ss, ee) =>
               {
                   try
                   {
                       if (ee.LeftButton == MouseButtonState.Pressed)
                       {
                           var myForm = (mw);
                           double mouseX = eVent.GetPosition(main).X, mouseY = eVent.GetPosition(main).Y;
                           Point currentPoint = ee.GetPosition(main);
                           if ((mouseX > 0) && (mouseX < main.ActualWidth) && (mouseY > 0) && (mouseY < main.ActualHeight)
                               && Math.Abs(currentPoint.X - InitMousePos.X) > SystemParameters.MinimumHorizontalDragDistance &&
                                       Math.Abs(currentPoint.Y - InitMousePos.Y) > SystemParameters.MinimumVerticalDragDistance && isHeader)
                           {
                               myForm.Margin = new Thickness(ee.GetPosition(main).X, ee.GetPosition(main).Y, 0, 0);
                              
                           }
                       }
                       else
                       {
                           Mouse.Capture(null);
                           isHeader = false;
                       }

                   }
                   catch (Exception ex) { MessageBox.Show(ex.Message); }
               };

           };
           mw.btnX.Click += (s, arg) =>
           {
               CloseWindow(main, mw);
           };
     
           

           if (FindChild<UserControl>(main, mw.Name) == null)
           {
               main.Children.Add(mw);
               mw.targetWindow.Children.Add(userControl);

               mw.Width = userControl.Width;

               mw.Height = userControl.Height;


           }
          

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
      public void CloseWindow(Canvas main, ContainerWindow mw)
      {
          main.Children.Remove(FindChild<UserControl>(main, mw.Name));
      }
   }
}
