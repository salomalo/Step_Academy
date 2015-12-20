using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace redactor
{
    public partial class Form1 : Form
    {
        public String DocName { set; get; }
        public String BufferText { set; get; }
        public float Size { set; get; }

        public Form1()
        {
            InitializeComponent();

            InstalledFontCollection ifc = new InstalledFontCollection();
            foreach (var family in ifc.Families)
            {
                cbFontStyle.Items.Add(family.Name);
            }
            DocName = "";

            FontDialog ft = new FontDialog();
            Size = richTextBox1.SelectionFont.GetHeight();
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += Form1_DragEnter;
            richTextBox1.DragDrop += Form1_DragDrop;

       
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }


        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                String [] path = (String[])(e.Data.GetData(DataFormats.FileDrop));
                richTextBox1.LoadFile(path[0] );
            }
        }


        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = true;
            //fd.InitialDirectory = "E:";
            fd.Filter = "rtf|*.rtf|txt|*.txt";

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (fd.FileName == "")
                { 
                    return; 
                }
                else 
                {
                    if (fd.FileName.EndsWith(".rtf"))
                    {
                        richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.RichText);
                        //    StreamReader sr = new StreamReader(fd.FileName);
                        //    richTextBox1.Text = sr.ReadToEnd();
                        //    sr.Close();
                        //    Text = fd.FileName;
                        //    DocName = fd.FileName;
                    }
                    else {
                        richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
            }
        } // OPEN

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {                   
 
                if (DocName != "")
                {
                    richTextBox1.SaveFile(DocName);
                }
                else
                {
                    SaveAs();
                }
          
        } // save in to the file which was open 

        private void SaveAs()
        {
            SaveFileDialog save = new SaveFileDialog(); 
            save.Filter = "rtf|*.rtf|txt|*.txt";  
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (save.FileName.EndsWith("rtf"))
                {
                    richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                }
            }     
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAs();
        } //save in to the new file

        private void cbFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
           richTextBox1.SelectionFont = new Font(cbFontStyle.SelectedItem.ToString(), 12f, FontStyle.Regular);
        } // fontStyle Change

        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SelectionColor = cld.Color;
                //this.BackColor = cld.Color;
            }
        }

        private void BGColor_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = cld.Color;
            }
        }

		
		
		
		
		
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = BufferText;
        }

        private void catToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BufferText = richTextBox1.SelectedText;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Size += 1;
            String style=richTextBox1.SelectionFont.FontFamily.ToString();
            richTextBox1.SelectionFont = new Font(style, Size, FontStyle.Regular);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Size -= 1;
            String style = richTextBox1.SelectionFont.FontFamily.ToString();
            richTextBox1.SelectionFont = new Font(style, Size, FontStyle.Regular);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll(); 
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void toolBold_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Underline);
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child child = new child();
            child.MdiParent = this;
            child.Show();

        }

    

       


    }
}