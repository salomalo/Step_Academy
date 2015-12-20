using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_SystemDialogs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = true;
            fd.InitialDirectory = "D:";
            fd.Filter = "Text files|*.txt|CS files|*.cs|All files|*.*";
            
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               // textBox1.Text = fd.FileName;
                textBox1.Text = fd.SafeFileName;
            }
			
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.AddExtension = true;
            sd.DefaultExt = "cs";
            if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sd.FileName, "Some content");
            }
			
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderD = new FolderBrowserDialog();
            folderD.ShowNewFolderButton = false;
            folderD.Description = "Somthing";
           
            if (folderD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = folderD.SelectedPath;
            }
        }
		
		

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
           // cld.SolidColorOnly = true;
           // cld.AnyColor = false;
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BackColor = cld.Color;
            }
        }
		
		

        private void button5_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowColor = true;
            if (font.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                label1.Font = font.Font;
                label1.ForeColor = font.Color;
            }
        }
    }
}
