using BS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Business.Managers.Abstract
{
    public interface IProducerManager : IManager
    {
        IEnumerable<Producer> GetAll();
    }
}
