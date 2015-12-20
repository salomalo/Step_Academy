using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_VisitCardViewer.Core.Abstract
{
    public abstract class CustomerStore
    {
        public abstract void Save(CustomerModel model);
        public abstract List<CustomerModel> Customers { get; set; }
    }
}