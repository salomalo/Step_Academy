using _03_VisitCardViewer.Core.Abstract;
using _03_VisitCardViewer.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_VisitCardViewer.Pages
{
    public partial class Home : BasePage
    {

        private static CustomerStore staticStore = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            staticStore = store;
            if (!IsPostBack)
            {
                dgCustomers.DataSource = store.Customers;
                dgCustomers.DataBind();
                
                cblCustomers.DataSource = store.Customers;
                cblCustomers.DataBind();
                foreach (var i in cblCustomers.Items)
                {
                    (i as ListItem).Selected = true;
                }

            }
        }

        protected void btnRegisterCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/RegisterCard.aspx");
        }
        
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static string[] GetCompletionList(string prefixText, int count)
        {
            var res = staticStore.Customers.Where(c => c.Name.Contains(prefixText))
                .Take(count)
                .Select(i => i.Name)
                .ToArray();

            return res;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            var lst = new List<int>();
            foreach (ListItem i in cblCustomers.Items)
            {
                if (i.Selected) {
                    lst.Add(Convert.ToInt32(i.Value));
                }
            }

            dgCustomers.DataSource = store.Customers.Where(c => lst.Contains(c.Id));
            dgCustomers.DataBind();

        }
    }
}