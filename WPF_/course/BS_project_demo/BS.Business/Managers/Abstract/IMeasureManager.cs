using BS.Entities;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IMeasureManager : IManager
    {
        IEnumerable<Measure> GetAll();
    }
}
