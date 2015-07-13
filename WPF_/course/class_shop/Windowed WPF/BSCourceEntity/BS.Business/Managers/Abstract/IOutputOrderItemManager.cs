using BS.Entity;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IOutputOrderItemManager : IManager
    {
        IEnumerable<OutputOrderItems> GetAll();
    }
}
