using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redactor
{
    public partial class child : Form
    {
        public child()
        {
            InitializeComponent();

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
                String[] path = (String[])(e.Data.GetData(DataFormats.FileDrop));
                 richTextBox1.LoadFile(path[0] );
            }
        }

        public void Undo()
        {
            richTextBox1.Undo();
        }

        public void Redo()
        {
            richTextBox1.Redo();
        }

        public void LoadFile(OpenFileDialog fd)
        {
            richTextBox1.LoadFile(fd.FileName, RichTextBoxStreamType.PlainText);
        }

        public void SaveFile(String DocName)
        {
            richTextBox1.SaveFile(DocName);
        }

        public void SaveAs()
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

        public void fontStyle(String font)
        {

            richTextBox1.SelectionFont = new Font(font, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);
       
        }

        public void ColorClick(ColorDialog cld)
        {
            richTextBox1.SelectionColor = cld.Color;
            this.BackColor = cld.Color;
        }

        public void BGColor_Click(ColorDialog cld)
        {
            richTextBox1.SelectionBackColor = cld.Color;
        }

        public void Paste(String BufferText)
        {
            richTextBox1.SelectedText = BufferText;
        }

        public void Cat(String BufferText)
        {
            BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }

        public void Copy(String BufferText)
        {
            BufferText = richTextBox1.SelectedText;
        }

        public void Clear()
        {
            richTextBox1.Clear();
        }

        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }

        public void SizeChange(bool Size)
        {
              String fontFamily = richTextBox1.SelectionFont.FontFamily.ToString();
              if (Size == true)
              {
                  richTextBox1.SelectionFont = new Font(fontFamily, richTextBox1.SelectionFont.Size+1, richTextBox1.SelectionFont.Style);
              }
              else
                  richTextBox1.SelectionFont = new Font(fontFamily, richTextBox1.SelectionFont.Size - 1, richTextBox1.SelectionFont.Style);
        }

        public void Bold()
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Bold);
        }

        public void Italic()
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
        }

        public void Underline()
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style ^ FontStyle.Underline);
        }

    }

}
