using BS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Business.Managers.Abstract
{
    public interface IPriceManager : IManager
    {
        IEnumerable<Prices> GetAll();
        void Insert(Prices newPr);
    }
    
}
