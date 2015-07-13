using BS.Entity;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IInputOrderItemManager : IManager
    {
        IEnumerable<InputOrderItems> GetAll();
    }
}
