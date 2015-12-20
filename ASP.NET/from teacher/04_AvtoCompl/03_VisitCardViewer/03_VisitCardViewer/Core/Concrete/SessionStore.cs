using _03_VisitCardViewer.Core.Abstract;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace _03_VisitCardViewer.Core.Concrete
{
    public class SessionStore : CustomerStore
    {
        public static readonly string collectionKey = "customers";
        public HttpSessionState Session { get; private set; }

        public SessionStore(HttpSessionState session)
        {
            Session = session;
        }
        public override void Save(CustomerModel model)
        {
            model.Id = (Customers.Count == 0) ? 0 : Customers.Max(c => c.Id) + 1;
            Customers.Add(model);
        }

        public override List<CustomerModel> Customers
        {
            get
            {
                if (Session[collectionKey] == null)
                {
                    Session[collectionKey] = new List<CustomerModel>();
                }
                return Session[collectionKey] as List<CustomerModel>;
            }
            set
            {
                Session[collectionKey] = value;
            }
        }
    }
}