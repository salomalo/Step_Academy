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
using System.Xml;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public bool IsName { set; get; }
        public bool IsSurname { set; get; }
        public bool IsBirthday { set; get; }
        public bool IsLogin { set; get; }
        public bool IsPassword { set; get; }
        public bool IsConfirm { set; get; }
        public bool IsAccept { set; get; }
        public bool IsGender { set; get; }

        public const int validFildsCount = 8;

        public int check { set; get; }
        public Form1()
        {
            InitializeComponent();
            btnSave.Enabled = false;
            tbxAge.Enabled = false;
            tbxConfirm.UseSystemPasswordChar = true;
            toolStripStatusLabel1.Text = "Not Saved";

            IsName = false;
            IsSurname = false;
            IsBirthday = false;
            IsLogin = false;
            IsPassword = false;
            IsConfirm = false;
            IsAccept = false;
            IsGender = false;
            check = 0;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (bdPicker.Checked == true)
            {
                check += 1;
                IsBirthday = true;
            }         
            int d =DateTime.Today.Year-bdPicker.Value.Year; 
            tbxAge.Text = d.ToString();
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbxPassword.Text.Length != 0)
            {
                check += 1;
                IsPassword = true;
            }         
        }

        private void tbxConfirm_TextChanged(object sender, EventArgs e)
        {
            Color  c = tbxConfirm.BackColor;
            String pas = tbxPassword.Text;
            String con = tbxConfirm.Text;

            if (con != pas)
            {
                tbxConfirm.BackColor = Color.Red;
            }
 
            if (con == pas)
            {
                check += 1;
                IsConfirm = true;
                tbxConfirm.BackColor = Color.Green;
            }
        }


        private bool Validate()
        {
            if(IsName == true && IsSurname == true 
                && IsBirthday == true && IsLogin == true 
                && IsPassword == true && IsConfirm == true
                && IsAccept == true && IsGender == true)
            {
                return true;
            }
            return false;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (IsLogin != false && Validate() == true)
            {
                toolStripProgressBar1.Value += toolStripProgressBar1.Maximum;
                MessageBox.Show("all good");
                String fileName = tbxLogin.Text + ".xml";
                XmlTextWriter writer = null;
                try
                {
                    writer = new XmlTextWriter(fileName, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented; //для читабельного формату 
                    writer.WriteStartDocument();
                    writer.WriteStartElement("users");
                    writer.WriteStartElement("user");
                    writer.WriteElementString("name", tbxName.Text);
                    writer.WriteElementString("surname", tbxSurname.Text);
                    writer.WriteElementString("Login", tbxLogin.Text);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    toolStripStatusLabel1.Text = "Saved";
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message);
                }
                catch (Exception ke)
                {
                    Console.WriteLine(ke.Message);
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
            }
            else 
            {
                //// 
                toolStripProgressBar1.Value -= toolStripProgressBar1.Maximum / check;
                MessageBox.Show("...bad...");
            }

           

        } // btnSave_Click

        private void checkBox6_CheckedChanged(object sender, EventArgs e) // Save
        {
         
            if (cbxPermision.Checked == false)
            {
                btnSave.Enabled = false;
            }
            if (cbxPermision.Checked == true)
            {
                check += 1;
                IsAccept = true;
                btnSave.Enabled = true;
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            if (tbxName.Text.Length > 0)
            {
              
                if (!IsName)
                {
                //    check += 1;
                    toolStripProgressBar1.Value += toolStripProgressBar1.Maximum/validFildsCount;
                    IsName = true;
                }
                
            }
            else
            {
                if (IsName)
                {
                    toolStripProgressBar1.Value -= toolStripProgressBar1.Maximum / validFildsCount;
                    IsName = false;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbxName.Clear();
            tbxSurname.Clear();
            tbxLogin.Clear();
            tbxPassword.Clear();
            tbxConfirm.Clear();
            tbxConfirm.BackColor = Color.White;
            tbxAge.Clear();
            bdPicker.Refresh();
            toolStripProgressBar1.Value += toolStripProgressBar1.Minimum;
            /////////////////////////////////////////
        }

        private void btnAdd_Click(object sender, EventArgs e) // transport from checkboxlist  to list
        {
            foreach (var el in cbxAllLanguage.CheckedItems)
            {
                lstLanguage.Items.Add(el);
            }
            for (int i = cbxAllLanguage.SelectedItems.Count - 1; i >= 0; i--)
            {
                cbxAllLanguage.Items.Remove(cbxAllLanguage.SelectedItems[i]);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) // transport from list to checkboxlist
        {
            foreach (var el in lstLanguage.SelectedItems)
            {
                cbxAllLanguage.Items.Add(el);
            }

            for (int i = lstLanguage.SelectedItems.Count - 1; i >= 0; i--)
            {
                lstLanguage.Items.Remove(lstLanguage.SelectedItems[i]);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
           // foreach (String el in System.IO.Directory.GetFiles(path))
            foreach (String el in    Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                if(el.EndsWith("xml"))
                {
                    cbxUsers.Items.Add((new FileInfo(el)).Name);
                }
            }
        }

        private void tbxSurname_TextChanged(object sender, EventArgs e)
        {
            check += 1;
            IsSurname = true;
        }

        private void tbxLogin_TextChanged(object sender, EventArgs e)
        {        
            String fileName = tbxLogin.Text + ".xml";
            String path = Directory.GetCurrentDirectory();
            DirectoryInfo dir = new DirectoryInfo(path);
            
            var res = dir.GetFiles();
            foreach (FileInfo el in res)
            {
                if(fileName!=el.Name)
                {
                    check += 1;
                    IsLogin = true;
                }
                else
                {
                    IsLogin = false;
                    MessageBox.Show("oops");
                }
            }


        }
    
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true )
            {
                check += 1;
                IsGender = true;
            }             
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                check += 1;
                IsGender = false;
            }
        }

        private void btnOpenUserFile_Click(object sender, EventArgs e)
        {
            String fileName = tbxLogin.Text + ".xml";
            foreach (var el in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                cbxUsers.Items.Add((new FileInfo(el)).Name);
            }

            ///////////////////
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = true;
            fd.InitialDirectory = "D:";
            fd.Filter = "Text files|*.txt|CS files|*.cs|All files|*.* |XML files| *.xml";

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // textBox1.Text = fd.FileName;
                // textBox1.Text = fd.SafeFileName;               
                // tbxName.Text=fd.
                // cbxUsers.Items.Add((new FileInfo(el)).Name);
                tbxName.Text = fd.SafeFileName;
            }
        }

        private void btnSaveToFolder_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "xml";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlTextWriter writer = null;
                try
                {
                    writer = new XmlTextWriter(save.FileName, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented; //для читабельного формату 
                    writer.WriteStartDocument();
                    writer.WriteStartElement("users");
                    writer.WriteStartElement("user");
                    writer.WriteElementString("name", tbxName.Text);
                    writer.WriteElementString("surname", tbxSurname.Text);
                    writer.WriteElementString("Login", tbxLogin.Text);
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    toolStripStatusLabel1.Text = "Saved";
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message);
                }
                catch (Exception ke)
                {
                    Console.WriteLine(ke.Message);
                }
                finally
                {
                    if (writer != null)
                    {
                        writer.Close();
                    }
                }
            }
        }


        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BackColor = cld.Color;
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.ShowColor = true;
            if (font.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cbxPermision.Font = font.Font;
                cbxPermision.ForeColor = font.Color;
            }
        }


        private void cbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            String file = cbxUsers.SelectedItem.ToString();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(file);
                XmlNodeList list = doc.GetElementsByTagName("user");
                foreach (XmlNode node in list)
                {
                  
                    tbxName.Text =node["name"].InnerText;
                    tbxLogin.Text = node["surname"].InnerText;
                    tbxSurname.Text = node["Login"].InnerText;
                }
            }
            catch (IOException ne)
            {
                Console.WriteLine(ne.Message);
            }
        }



    }
}