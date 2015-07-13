using BS.Entity;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IStatusManager : IManager
    {
        IEnumerable<Statuses> GetAll();
    }
}
