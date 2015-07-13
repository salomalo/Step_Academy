using BS.Entity;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IInputOrderManager : IManager
    {
        IEnumerable<InputOrders> GetAll();
    }
}
