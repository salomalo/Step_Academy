using BS.Entity;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IOutputOrderManager : IManager
    {
        IEnumerable<OutputOrders> GetAll();
    }
}
