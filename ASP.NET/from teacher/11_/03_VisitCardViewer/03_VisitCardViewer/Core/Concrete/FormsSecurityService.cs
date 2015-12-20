using _03_VisitCardViewer.Core.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace _03_VisitCardViewer.Core.Concrete
{
    public class FormsSecurityService:ISecurityService
    {

        IUserProfileDataManager userProfileManager = new UserProfileDataManager();

        #region ISercurityService Members

        public bool Login(string login, string password, bool remember = false)
        {
            if (!userProfileManager.IsValid(login, password))
            {
                HttpContext.Current.User = null;
                return false;
            }
            DefinePrincipal(login);
            FormsAuthentication.SetAuthCookie(login, remember);
            return true;
        }

        public void RefreshPrincipal()
        {
            IPrincipal principal = HttpContext.Current.User;
            if (principal != null && principal.Identity != null && principal.Identity.IsAuthenticated)
            {
                DefinePrincipal(principal.Identity.Name);
            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.User = null;
        }

        #endregion

        #region Helpers

        private void DefinePrincipal(string userName)
        {
            IIdentity identity = new GenericIdentity(userName);
            string[] roles = userProfileManager.GetUserRoles(userName);
            HttpContext.Current.User = new GenericPrincipal(identity, roles);
        }
        #endregion
    }
}