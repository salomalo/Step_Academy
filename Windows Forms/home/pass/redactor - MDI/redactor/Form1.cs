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
        public bool Size { set; get; }

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
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragEnter += Form1_DragDrop;
            
            
            //richTextBox1.AllowDrop = true;
            //richTextBox1.DragEnter += Form1_DragEnter;
            //richTextBox1.DragDrop += Form1_DragDrop;
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
              

                //  richTextBox1.LoadFile(path[0] );


            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // richTextBox1.Undo();
            
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   richTextBox1.Redo();
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Redo();
            }
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
           //             richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.RichText);
                        //    StreamReader sr = new StreamReader(fd.FileName);
                        //    richTextBox1.Text = sr.ReadToEnd();
                        //    sr.Close();
                        //    Text = fd.FileName;
                        //    DocName = fd.FileName;
                    }
                    else {

                        //   richTextBox1.Redo();
                        if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
                        {
                            (this.ActiveMdiChild as child).LoadFile(fd);
                        }
           //             richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.PlainText);

                    }
                }
            }
        } // OPEN

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {                   
                if (DocName != "")
                {
          //          richTextBox1.SaveFile(DocName);
                    if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
                    {
                        (this.ActiveMdiChild as child).SaveFile(DocName);
                    }
                }
                else
                {
                 //   SaveAs();
                    if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
                    {
                        (this.ActiveMdiChild as child).SaveAs();
                    }
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
          //          richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
           //         richTextBox1.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                }
            }     
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   SaveAs();

            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).SaveAs();
            }
        } //save in to the new file


        private void cbFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).fontStyle(cbFontStyle.SelectedItem.ToString());
            }
        } // fontStyle Change


        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
                {
                    (this.ActiveMdiChild as child).ColorClick(cld);
                }
            }
        }


        private void BGColor_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
                {
                    (this.ActiveMdiChild as child).BGColor_Click(cld);
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Paste(BufferText);
            }
        }

        private void catToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Cat(BufferText);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Copy(BufferText);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).SelectAll();
            }
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Undo();
            }
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Redo();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Clear();
            }
        }

        private void toolBold_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Bold();
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Italic();
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).Underline();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Size =true;
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).SizeChange(Size);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Size =false;
            if (this.ActiveMdiChild != null && (this.ActiveMdiChild is child))
            {
                (this.ActiveMdiChild as child).SizeChange(Size);
            }
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            child child = new child();
            child.MdiParent = this;
            child.Show();
        }

    }
}