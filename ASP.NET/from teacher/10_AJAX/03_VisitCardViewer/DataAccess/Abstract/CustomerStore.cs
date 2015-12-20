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
        public abstract void SaveProfile(CustomerProfile profile);
        public abstract void SaveVisitCard(VisitCardModel card);
        public abstract List<CustomerProfile> Customers { get; set; }
    }
}
