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

namespace FileComparer
{
    public partial class Form1 : Form
    {
        public string File1;
        public string File2;

        public string path;

        public Form1()
        {
            InitializeComponent();
            path = "@C:\\My Documnets\\";
        }

        private void btnOpenFile1_Click(object sender, EventArgs e)
        {
            OpenFile(tbFile1, ref File1);
        }

        private void btnOpenFile2_Click(object sender, EventArgs e)
        {
            OpenFile(tbFile2, ref File2);
        }

        public void OpenFile(RichTextBox tb, ref string file)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            openFile1.InitialDirectory = path;
            openFile1.DefaultExt = "*.txt";
            openFile1.Filter = "txt Files|*.txt|rtf Files|*.rtf|All Files|*.* |bmp Files|*.bmp";
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               openFile1.FileName.Length > 0)
            {
                try
                {
                    tb.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), ex.Source);
                }
            }
            file = openFile1.FileName;

            string tmp = file;
            string tmp2 = openFile1.SafeFileName;
            path = tmp.Remove(tmp.Length - tmp2.Length, tmp2.Length);

        } // OpenFile

        //http://www.linux.org.ru/forum/development/7311586
        public void Comp(string file1, string file2)
        {
            //int file1byte;
            //int file2byte;
            //FileStream fs1;
            //FileStream fs2;

            //if (file1 == file2)
            //{
            //    return true;
            //}

            //fs1 = new FileStream(file1, FileMode.Open);
            //fs2 = new FileStream(file2, FileMode.Open);

            //if (fs1.Length != fs2.Length)
            //{
            //    fs1.Close();
            //    fs2.Close();
            //    return false;
            //}

            //do
            //{
            //    // Read one byte from each file.
            //    file1byte = fs1.ReadByte();
            //    file2byte = fs2.ReadByte();
            //}
            //while ((file1byte == file2byte) && (file1byte != -1));

            //fs1.Close();
            //fs2.Close();

            //return ((file1byte - file2byte) == 0);            

            string[] NewFile = File.ReadAllLines(File1);
            string[] NewFile2 = File.ReadAllLines(File2);

            int StartPosition = 0;

            for (int i = 0; i < NewFile.Length; i++)
            {
                if (NewFile[i] == NewFile2[i])
                {
                    //MessageBox.Show("true");
                    StartPosition++;
                }
                else
                {
                    //MessageBox.Show("false");
                    tbFile1.SelectionStart = StartPosition + 1;
                    tbFile1.SelectionLength = NewFile[i].Length;
                    tbFile1.SelectionBackColor = Color.Aqua;

                }
            }
        }


        private void btnCompare_Click(object sender, EventArgs e)
        {

            Comp(File1, File2);
        }

    }
}