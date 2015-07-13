using BS.Entities;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IProducerManager : IManager
    {
        IEnumerable<Producer> GetAll();
    }
}
