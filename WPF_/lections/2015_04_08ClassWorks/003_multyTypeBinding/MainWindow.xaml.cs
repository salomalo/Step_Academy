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

namespace _003_multyTypeBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Family> families = new List<Family>();

            Family simpsons = new Family { Name = "The Simpsons" };
            simpsons.FamilyItems.Add(new FamilyItem { Name = "Homer", Age = 38 });
            simpsons.FamilyItems.Add(new FamilyItem { Name = "Marge", Age = 37 });
            simpsons.FamilyItems.Add(new FamilyItem { Name = "Bart", Age = 10 });
            simpsons.FamilyItems.Add(new FamilyItem { Name = "Lisa", Age = 8 });
            simpsons.FamilyItems.Add(new FamilyItem { Name = "Maggie", Age = 1 });

            families.Add(simpsons);

            Family flanders = new Family { Name = "The Flanders" };
            flanders.FamilyItems.Add(new FamilyItem { Name = "Ned", Age = 45 });
            flanders.FamilyItems.Add(new FamilyItem { Name = "Maude", Age = 38 });
            flanders.FamilyItems.Add(new FamilyItem { Name = "Todd", Age = 7 });
            flanders.FamilyItems.Add(new FamilyItem { Name = "Rod", Age = 5 });

            families.Add(flanders);

            tvFamilies.ItemsSource = families;
        }
    }

    public class FamilyItem
    {
        public string Name { set; get; }
        public int Age { set; get; }
    }

    public class Family
    {
        public string Name { set; get; }
        public List<FamilyItem> FamilyItems { set; get; }

        public Family()
        {
            FamilyItems = new List<FamilyItem>();
        }
    }
}
