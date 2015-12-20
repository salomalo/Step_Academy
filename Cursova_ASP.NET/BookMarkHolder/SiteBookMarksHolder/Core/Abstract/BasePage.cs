using ClassDBAccess;
using ClassDBAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SiteBookMarksHolder.Core.Abstract
{
    public class BasePage : Page
    {
        protected BookmarkHolder holder = null;
        protected override void OnLoad(EventArgs e)
        {
            holder = new DBHolder();
            base.OnLoad(e); // OnLoad method of base class must be called while overriding!!!
        }


    }
}