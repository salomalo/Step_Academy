using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ftp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Connect();
        }
        FtpWebRequest request;

        public void Connect()
        { 
            request = (FtpWebRequest)WebRequest.Create("ftp://f9-preview.runhosting.com");
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;          
            request.Credentials = new NetworkCredential("1883710_GreenDay", "GreenDay313");
           
           //reader.Close();
           //response.Close();     
        }

        private void All_Click(object sender, EventArgs e)
        {
            AllFiles();
        }

        public void AllFiles()
        {
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream);

            List<string> directories = new List<string>();
            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }

            foreach (String s in directories)
            {
                richTextBox1.Text += s+ " \n";
            }         
        }

        private void button1_Click(object sender, EventArgs e)
        {
    

        }



        private void add_Click(object sender, EventArgs e)
        {
           // string Content = "io";

           // Uri TempURI = new Uri(Path.Combine("ftp://f9-preview.runhosting.com", ""));
           // FtpWebRequest FTPRequest = (FtpWebRequest)FtpWebRequest.Create(TempURI);
           //// FTPRequest.Credentials = new NetworkCredential(UserName, Password);
           // FTPRequest.KeepAlive = false;
           // FTPRequest.Method = WebRequestMethods.Ftp.UploadFile;
           // FTPRequest.UseBinary = true;
           // FTPRequest.ContentLength = Content.Length;
           // FTPRequest.Proxy = null;

           // using (Stream TempStream = FTPRequest.GetRequestStream())
           // {
           //     System.Text.ASCIIEncoding TempEncoding = new System.Text.ASCIIEncoding();
           //     byte[] TempBytes = TempEncoding.GetBytes(Content);
           //     TempStream.Write(TempBytes, 0, TempBytes.Length);
           // }
           // FTPRequest.GetResponse();

            string ftphost = "ftp://f9-preview.runhosting.com";
            string ftpfullpath = "ftp://" + ftphost + Environment.MachineName;

            FtpWebRequest ftp = (FtpWebRequest)WebRequest.Create(ftpfullpath);
           // ftp.Credentials = new NetworkCredential("login", "password");
            ftp.KeepAlive = false;
            ftp.UseBinary = true;
            ftp.UsePassive = false;
            ftp.Proxy = null;
            ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
            FtpWebResponse resp = (FtpWebResponse)ftp.GetResponse();


        } //all


    }
}
