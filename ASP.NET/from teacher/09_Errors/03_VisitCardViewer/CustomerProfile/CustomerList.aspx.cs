using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_VisitCardViewer.CustomerProfile
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    throw new Exception("Oups!");
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Db Failure", ex);
            //}
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CustomerProfile/AddCustomerProfile.aspx");
        }
    }
}