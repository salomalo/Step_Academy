using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_ListView
{
    public partial class Form1 : Form
    {
        int view = -1;
        ImageList smallImages = new ImageList();
        ImageList largeImages = new ImageList();
        
        public Form1()
        {
            InitializeComponent();

            InitializeListView();
        }

        private void CreateImageList(ImageList il, string path)
        {
            il.ColorDepth = ColorDepth.Depth32Bit;
            string[] files = System.IO.Directory.GetFiles(path);

            foreach (var file in files)
            {
                if (file.EndsWith("ico") || file.EndsWith("png"))
                {
                    il.Images.Add(new Bitmap(file));
                }
            }

        }

        private void InitializeListView()
        {
            CreateImageList(smallImages, @"..\..\images\smallImages");
            smallImages.ImageSize = new Size(16, 16);

            CreateImageList(largeImages, @"..\..\images\largeImages");
            largeImages.ImageSize = new Size(32, 32);

            listView1.LargeImageList = largeImages;
            listView1.SmallImageList = smallImages;

            int w = listView1.Width / 5;

            listView1.Columns.Add("name", "First Name", w);
            listView1.Columns.Add("lastname", "Last Name",w);
            listView1.Columns.Add("age", "Age", w);
            listView1.Columns.Add("group", "Group", w);
            listView1.Columns.Add("mark", "Averege Mark", w);



            listView1.Items.Add("Hello");
            listView1.Items.Add("Bye", 0);
            listView1.Items.Add(new ListViewItem("Some", 1));
            
            Student st1 = new Student("Tomas", "Mor", 20, "23NS19", 10);
            Student st2 = new Student("Marie", "Remarke", 18, "23NS20", 12);
            Student st3 = new Student("Mark", "Twan", 21, "23NS29", 9);           

    
            listView1.Items.Add(new ListViewItem(new string[] {st1.FirstName,
                                                               st1.LastName,
                                                               st1.Age.ToString(),
                                                               st1.Group,
                                                               st1.Average.ToString()},3));
            listView1.Items.Add(new ListViewItem(new string[] {st2.FirstName,
                                                               st2.LastName,                                                              
                                                               st2.Group,
                                                               st2.Average.ToString()}, 4));
            listView1.Items.Add(new ListViewItem(new string[] {st3.FirstName,
                                                               st3.LastName,
                                                               st3.Age.ToString(),
                                                               st3.Group,
                                                               st3.Average.ToString(),
                                                                "will I see this?"}, 2));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view++;

            view = view > 4 ? 0 : view;
            switch (view)
            {
                case 0:
                    listView1.View = View.Details;
                    break;
                case 1:
                    listView1.View = View.LargeIcon;
                    break;
                case 2:
                    listView1.View = View.List;
                    break;
                case 3:
                    listView1.View = View.SmallIcon;
                    break;
                case 4:
                    listView1.View = View.Tile;
                    break;
            }

            //label1.Text = listView1.View.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var item = listView1.SelectedItems[0];

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    sb.Append(item.SubItems[i].Text);
                    sb.Append(" ");
                }
                MessageBox.Show(sb.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var items = listView1.SelectedItems;

            foreach (ListViewItem item in items)
            {
                listView1.Items.Remove(item);
            }
        }


        
    }


    public class Student
    {
        public String FirstName { set; get; }
        public String LastName { set; get; }
        public int Age { set; get; }
        public String Group { set; get; }
        public int Average { set; get; }

        public Student(String firstName, String lastName, int age, String group, int average)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Group = group;
            Average = average;
        }



    }
}
