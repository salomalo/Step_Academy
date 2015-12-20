using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;

namespace WF_Menus
{
    public partial class Form1 : Form
    {
        ImageList list;
        public Form1()
        {
            InitializeComponent();
            list = new ImageList();
            InitImageList(@"D:/", list);
           
            toolStrip2.ImageList = list;
            toolStripButton2.ImageIndex = 0;
            toolStripButton3.ImageIndex = 1;

            SetFonts();
        }


        private void InitImageList(string path, ImageList images)
        {
            images.ImageSize = new Size(16, 16);
            
            foreach(string file in System.IO.Directory.GetFiles(path))
            {
                if (file.EndsWith("png") || file.EndsWith("ico"))
                {
                    list.Images.Add(new Bitmap(file));
                    
                }
            }
        }

        private void SetFonts()
        {
            InstalledFontCollection ifc = new InstalledFontCollection();
            foreach (var family in ifc.Families)
            {
                cbFonts.Items.Add(family.Name);
              
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            menuStrip1.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            menuStrip1.Hide();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            New();
        }

        private void New()
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            New();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
        }

        private void cbFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
           richTextBox1.SelectionFont = new Font(cbFonts.SelectedItem.ToString(), 12f, FontStyle.Italic);
        }

        private void cbFonts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          //  File.WriteAllText(@"D:/text.txt", richTextBox1.Text);
            richTextBox1.SaveFile(@"D:/text3.rtf", RichTextBoxStreamType.RichText);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            richTextBox1.LoadFile(@"D:/text.rtf",RichTextBoxStreamType.RichText);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }
    }
}
