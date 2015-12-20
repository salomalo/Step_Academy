using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_VisitCardViewer.CustomerProfile
{
    public partial class AddCustomerProfile : System.Web.UI.Page
    {

        //1.
        //protected override void InitializeCulture()
        //{
        //    //UICulture = Request.UserLanguages[0];
        //    //UICulture = "ru-RU";
        //    base.InitializeCulture();
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            //2. Another option how to switch cultures
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");            
            ResourceManager rm = Resources.strings.ResourceManager;

            Label lblName = fvAddCustomer.FindControl("lblName") as Label;
            lblName.Text = rm.GetString("txtName");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CustomerProfile/CustomerList.aspx");
        }
    }
}