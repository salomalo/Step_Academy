using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeView_WF
{
    public partial class Form1 : Form
    {
        ImageList imageList;
        public Form1()
        {
            InitializeComponent();
            imageList = new ImageList();
            InitializImageList(@"../../Images", imageList);

            treeView1.ImageList = imageList;
            treeView1.ImageIndex = 0;
            treeView1.SelectedImageIndex= 1;

            InitializeTreeView();


        }

        private void InitializImageList(string path, ImageList list)
        {
            var files = System.IO.Directory.GetFiles(path);
            list.ImageSize = new Size(16, 16);

            foreach (var file in files)
            {
                if (file.EndsWith(".ico"))
                {
                    list.Images.Add(new Bitmap(file));
                }
            }

        }

        private void InitializeTreeView()
        {
            TreeNode root1 = new TreeNode("2014", 2,3);

            TreeNode winter1 = new TreeNode("Winter 2014");
            TreeNode january1 = new TreeNode("January 2014");
            TreeNode fabruary1 = new TreeNode("Fabruary 2014");

            winter1.Nodes.Add(january1);
            winter1.Nodes.Add(fabruary1);

            TreeNode march1 = new TreeNode("March 2014");
            TreeNode april1 = new TreeNode("April 2014");

            TreeNode spring1 = new TreeNode("Spring 2014", new TreeNode[] { march1, april1 });

            april1.Nodes.Add("first week");
            april1.Nodes.Add("second", "second week");
            april1.Nodes[0].Nodes.Add("Monday");
            april1.Nodes["second"].Nodes.Add("Monday");

            root1.Nodes.Add(winter1);
            root1.Nodes.Add(spring1);

            treeView1.Nodes.Add(root1);

            TreeNode root2 = new TreeNode("2015", 2, 3);

            TreeNode winter2 = new TreeNode("Winter 2015");
            TreeNode january2 = new TreeNode("January 2015");
            TreeNode fabruary2 = new TreeNode("Fabruary 2015");

            winter2.Nodes.Add(january2);
            winter2.Nodes.Add(fabruary2);

            TreeNode march2 = new TreeNode("March 2015");
            TreeNode april2 = new TreeNode("April 2015");

            TreeNode spring2 = new TreeNode("Spring 2015", new TreeNode[] { march2, april2 });

            april2.Nodes.Add("first week");
            april2.Nodes.Add("second", "second week");
            april2.Nodes[0].Nodes.Add("Monday");
            april2.Nodes["second"].Nodes.Add("Monday");

            root2.Nodes.Add(winter2);
            root2.Nodes.Add(spring2);

            treeView1.Nodes.Add(root2);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            textBox1.Text = e.Node.FullPath;
        }
            
    }
}
