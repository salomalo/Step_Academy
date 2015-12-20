using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parking.Core.Abstract
{
    public abstract class CarStore
    {
        public abstract void Save(CarModel model);
        public abstract void Delete(CarModel model);
        public abstract List<CarModel> Cars { get; set; }
    }
}