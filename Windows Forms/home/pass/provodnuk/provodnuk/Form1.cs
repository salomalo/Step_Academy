using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace provodnuk
{
    public partial class Form1 : Form
    {

        int view = -1;
        ImageList smallImages = new ImageList();
        ImageList largeImages = new ImageList();
        
        String path = null;
  
        public Form1()
        {
            InitializeComponent();
            InitializeTreeView();
            CreateImageList(smallImages, @"../../Images/smallImages");
            CreateImageList(largeImages, @"../../Images/largeImages");
            listView1.SmallImageList = smallImages;
            listView1.LargeImageList = largeImages;
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


            //listView1.Columns.Add("size", "Size", w);
            //listView1.Columns.Add("type", "Type", w);
            //listView1.Columns.Add("date", "Date", w);


            //listView1.Items.Add("Hello");
            //listView1.Items.Add("Bye", 0);
            //listView1.Items.Add(new ListViewItem("Some", 1));

            //Student st1 = new Student("Tomas", "Mor", 20, "23NS19", 10);
            //Student st2 = new Student("Marie", "Remarke", 18, "23NS20", 12);
            //Student st3 = new Student("Mark", "Twan", 21, "23NS29", 9);

            //listView1.Items.Add(new ListViewItem(new string[] {st1.FirstName,
            //                                                   st1.LastName,
            //                                                   st1.Age.ToString(),
            //                                                  }, 3));

            //listView1.Items.Add(new ListViewItem(new string[] {st2.FirstName,
            //                                                   st2.LastName,                                                              
            //                                                   st2.Group,
            //                                                   }, 4));

            //listView1.Items.Add(new ListViewItem(new string[] {st3.FirstName,
            //                                                   st3.LastName,
            //                                                   st3.Age.ToString(),
            //                                                   }, 2));
        }

        public void AddNode(TreeNode root1)
        {
            try
            {
                var dirs = Directory.GetDirectories(root1.FullPath);
                path = root1.FullPath;

                foreach (String f in dirs)
                {
                    DirectoryInfo dir = new DirectoryInfo(f);
                    root1.Nodes.Add(dir.Name, dir.Name);
                    try
                    {
                        var folders = Directory.GetDirectories(f);
                        foreach (String fold in folders)
                        {
                            DirectoryInfo d = new DirectoryInfo(fold);
                            root1.Nodes[f].Nodes.Add(d.Name, d.Name);
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }


        private void InitializeTreeView()
        {
            var discs = Directory.GetLogicalDrives();
            foreach (String disc in discs)
            {
                treeView1.Nodes.Add(disc, disc);
                var folders = Directory.GetDirectories(disc);

                foreach (String folder in folders)
                {
                    DirectoryInfo d = new DirectoryInfo(folder);
                    treeView1.Nodes[disc].Nodes.Add(d.Name, d.Name);
                }
            }
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            path = e.Node.FullPath;
            textBox1.Text = path;
        }


        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            foreach (TreeNode node in e.Node.Nodes)
            {
                node.Nodes.Clear();
                AddNode(node);
            }
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(e.Node.FullPath);
            DirectoryInfo[] directoris = d.GetDirectories();
            FileInfo[] files = d.GetFiles();
            listView1.Clear();

            foreach (DirectoryInfo dir in directoris)
            {
                listView1.Items.Add(dir.Name, 1);
            }

            foreach (FileInfo fil in files)
            {
                listView1.Items.Add(fil.Name, 2);
            }
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
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

            toolStripLabel2.Text = listView1.View.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //String path = treeView1.SelectedNode.FullPath;

            //DirectoryInfo d = new DirectoryInfo(path);

            //DirectoryInfo[] directoris = d.GetDirectories();
            //FileInfo[] files = d.GetFiles();
            //listView1.Clear();

            //foreach (DirectoryInfo dir in directoris)
            //{
            //    if (searchField.Text == dir.Name)
            //    {

            //    }
            //}

            //foreach (FileInfo fil in files)
            //{

            //}
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            String tmp = path + '\\' + listView1.FocusedItem.Text;

            if (Directory.Exists(tmp))
            {
                path = tmp;
            }
            else {
                path = tmp;
                System.Diagnostics.Process.Start(path);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(path);
            if (Directory.Exists(path))
            {
                DirectoryInfo d = new DirectoryInfo(path);  
                DirectoryInfo[] directoris = d.GetDirectories();
                FileInfo[] files = d.GetFiles();

                path = Path.Combine(path, listView1.FocusedItem.Name);

                listView1.Clear();

                foreach (DirectoryInfo dir in directoris)
                {
                    listView1.Items.Add(dir.Name, 1);
                }
                foreach (FileInfo fil in files)
                {
                    listView1.Items.Add(fil.Name, 2);
                }
            }
            else {
                

            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(path);

            String newFolderName = "new folder";
            int number = 0;
            
            DirectoryInfo[] count = d.GetDirectories();

            foreach(DirectoryInfo dir in count)
            {
            if ( dir.Name.StartsWith("new folder"))
                {
                    number++;
                }
            }

            if (number > 0)
            {
                DirectoryInfo newFolder = new DirectoryInfo(Path.Combine(path, newFolderName + number));
                newFolder.Create();
                listView1.Items.Add(newFolder.Name, 2);
            }
            else
            {
                DirectoryInfo newFolder = new DirectoryInfo(Path.Combine(path, newFolderName));
                newFolder.Create();
                listView1.Items.Add(newFolder.Name, 2);
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var items = listView1.SelectedItems;

            foreach (ListViewItem item in items)
            {
                listView1.Items.Remove(item);
            }


            DirectoryInfo folder = new DirectoryInfo(path);
            DirectoryInfo[] count = folder.GetDirectories();
            
            foreach (DirectoryInfo dir in count)
            {
              
            }



        }


    }
}