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
        public override void Save(CarModel model)
        {
            Cars.Add(model);
        }


        //public override void Delete(CarModel model)
        //{
        //    Cars.Add(model);
        //}

        public override List<CarModel> Cars
        {
            get
            {
                if (Session[collectionKey] == null)
                {
                    Session[collectionKey] = new List<CarModel>();
                }
                return Session[collectionKey] as List<CarModel>;
            }
            set
            {
                Session[collectionKey] = value;
            }
        }
    }
}