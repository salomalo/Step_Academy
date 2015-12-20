using DataAccess.Abstract;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace DataAccess.Concrete
{
    public class SessionStore : CustomerStore
    {
        public static readonly string collectionKey = "customers";
        public HttpSessionState Session { get; private set; }

        public SessionStore(HttpSessionState session)
        {
            Session = session;
        }
        public override void Save(VisitCardModel model)
        {
            model.Id = (Customers.Count == 0) ? 0 : Customers.Max(c => c.Id) + 1;
            Customers.Add(model);
        }

        public override List<VisitCardModel> Customers
        {
            get
            {
                if (Session[collectionKey] == null)
                {
                    Session[collectionKey] = new List<VisitCardModel>();
                }
                return Session[collectionKey] as List<VisitCardModel>;
            }
            set
            {
                Session[collectionKey] = value;
            }
        }
    }
}
