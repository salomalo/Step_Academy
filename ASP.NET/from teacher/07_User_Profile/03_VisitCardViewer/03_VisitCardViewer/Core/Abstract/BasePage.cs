using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace _03_VisitCardViewer.Core.Abstract
{
    public class BasePage: Page
    {
        protected CustomerStore store = null;
        protected override void OnLoad(EventArgs e)
        {
            //store = new SessionStore(Session);
            store = new DbStore();
            base.OnLoad(e); // OnLoad method of base class must be called while overriding!!!
        }
    }
}