using _03_VisitCardViewer.Core.Abstract;
using _03_VisitCardViewer.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_VisitCardViewer.Login
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginControl_Authenticate(object sender, AuthenticateEventArgs e)
        {

            string login = loginControl.UserName;
            string pass = loginControl.Password;

            bool remember = loginControl.RememberMeSet;
            ISecurityService SecurityService = new FormsSecurityService();
            e.Authenticated = SecurityService.Login(login, pass, remember);
        }
    }
}