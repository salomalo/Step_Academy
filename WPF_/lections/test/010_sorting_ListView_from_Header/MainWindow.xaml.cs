using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace _010_sorting_ListView_from_Header
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader lvSortCol = null;
        private SortAdorner lvSortAdorner = null; 

        public MainWindow()
        {
            InitializeComponent();

            List<User> items = new List<User>();
            items.Add(new User { Name = "Mike", Age = 27, Email = "mike_smith@gmail.com" });
            items.Add(new User { Name = "Todd", Age = 31, Email = "todd_johnes@gmail.com" });
            items.Add(new User { Name = "Marie", Age = 30, Email = "marie_siemens@gmail.com" });
            items.Add(new User { Name = "Hoze", Age = 35, Email = "hoze_rodrigues@gmail.com" });
            lvwUsers.ItemsSource = items;

            CollectionView cv = CollectionViewSource.GetDefaultView(lvwUsers.ItemsSource) as CollectionView;
            cv.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));
            cv.SortDescriptions.Add(new System.ComponentModel.SortDescription("Age", System.ComponentModel.ListSortDirection.Ascending));

        }

        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader col = sender as GridViewColumnHeader;

            string sortBy = col.Tag.ToString();

            if (lvSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(lvSortCol).Remove(lvSortAdorner);
                lvwUsers.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (lvSortCol == col && lvSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            lvSortCol = col;
            lvSortAdorner = new SortAdorner(lvSortCol, newDir);
            AdornerLayer.GetAdornerLayer(lvSortCol).Add(lvSortAdorner);
            lvwUsers.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));

        }

    }

    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }

    public class SortAdorner : Adorner
    {
        private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

        private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement element, ListSortDirection dir)
            : base(element)
        {
            this.Direction = dir;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
                return;

            TranslateTransform transform = new TranslateTransform
            (
                AdornedElement.RenderSize.Width - 15,
                (AdornedElement.RenderSize.Height - 5) / 2
            );
            drawingContext.PushTransform(transform);

            Geometry geometry = ascGeometry;
            if (this.Direction == ListSortDirection.Descending)
                geometry = descGeometry;
            drawingContext.DrawGeometry(Brushes.Black, null, geometry);

            drawingContext.Pop();
        }    
    }
}
