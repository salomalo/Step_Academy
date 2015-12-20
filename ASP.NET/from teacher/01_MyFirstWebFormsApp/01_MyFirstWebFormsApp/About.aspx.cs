using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_MyFirstWebFormsApp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSetText_Click(object sender, EventArgs e)
        {
            tbSample.Text = "hello";
            tbSample.ReadOnly = true;
            tbSample.Enabled = false;
        }

        
    }
}