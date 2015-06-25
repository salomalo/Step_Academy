using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UICLient.ServiceReference1;

namespace UICLient
{
    public class User
    {
        public string LoginName;
        public string Pasword;

        public string Name;
        public string Surname;

        public string Token;
        public DateTime ExpDate;

        public string Sult;
        public string PasHash;
    }

    public partial class Form1 : Form
    {
        GetUserInfoClient user = new GetUserInfoClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            string tmpSult = user.GetSult(usLogin.Text);
            var token = user.Authorize(usLogin.Text, MakeHash(MakeHash(usPass.Text) + tmpSult),"name n","name l"); //, usName.Text, usSurname/Text );        
            var obj = JsonConvert.DeserializeObject<User>(token);

            MessageBox.Show(obj.Token.ToString());
        }

        public string MakeHash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }//MakeHash

    }

}
