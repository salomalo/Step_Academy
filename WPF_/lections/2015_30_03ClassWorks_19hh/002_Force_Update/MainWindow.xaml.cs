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

namespace _002_Force_Update
{
    public class MyClass
    {
        public string MyString { get; set; }

    }
    
    public partial class MainWindow : Window
    {
        private MyClass _myClass;

        public MainWindow()
        {
            InitializeComponent();

            _myClass = new MyClass();
            _myClass.MyString = "Some text";

            this.DataContext = _myClass;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _myClass.MyString = _tbNewValue.Text;
            BindingOperations.GetBindingExpressionBase(_lblValue, Label.ContentProperty).UpdateTarget();
        }
    }
}
