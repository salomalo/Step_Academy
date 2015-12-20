using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public abstract class CustomerStore
    {
        public abstract void Save(VisitCardModel model);
        public abstract List<VisitCardModel> Customers { get; set; }
    }
}
