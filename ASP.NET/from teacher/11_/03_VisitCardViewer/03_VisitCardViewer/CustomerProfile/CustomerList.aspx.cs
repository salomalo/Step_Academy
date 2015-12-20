using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DM = DataModel;

namespace _03_VisitCardViewer.CustomerProfile
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback && IsPostBack)
            {
                string str = ""; // when page called back
            }
            if (!IsCallback && IsPostBack)
            {
                string str = ""; // when postback
            }
            if (!IsCallback && !IsPostBack)
            {
                string str = ""; // new request
            }
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

        protected void ajaxAddDumpUser_Click(object sender, EventArgs e)
        {
            DM.CustomerProfile prof = new DM.CustomerProfile { 
                Birthday = DateTime.Now,
                Email = "blah@bl.com",
                Login = "test_cust",
                Name = "Test",
                Password = "1234567",
                Phone = "2342512356",
                Profession = "Tester",
                Role = DM.Roles.Client,
                Surname = "testoff"
            };
            Thread.Sleep(100000);
         
            DbStore store = new DbStore();
            store.SaveProfile(prof);
            lblAddStatus.Text = "User successfully added";
        }

        protected void RefreshGrid_Click(object sender, EventArgs e)
        {
            DbStore store = new DbStore();
            gvAjaxUsers.DataSource = store.GetAll();
            gvAjaxUsers.DataBind();
            dgCustomers.DataBind();

            
        }

        protected void lbtDelete_Click(object sender, EventArgs e)
        {

        }
        

    }
}