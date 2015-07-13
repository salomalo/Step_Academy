using BS.Entities;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IProductManager : IManager
    {
        IEnumerable<Product> GetAll();
    }
}
