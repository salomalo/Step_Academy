using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_VisitCardViewer.Core.Abstract
{
    public abstract class CustomerStore
    {
        public abstract void Save(CarModel model);

       // public abstract void Delete(CarModel model);
        public abstract List<CarModel> Cars { get; set; }
    }
}