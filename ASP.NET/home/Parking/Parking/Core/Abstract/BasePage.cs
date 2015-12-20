using Parking.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Parking.Core.Abstract
{
    public class BasePage:Page
    {
        protected CarStore store = null;

        protected override void OnLoad(EventArgs e)
        {
            store = new SessionStore(Session);
            base.OnLoad(e); // OnLoad method of base class must be called while overriding!!!
        }
    }
}


