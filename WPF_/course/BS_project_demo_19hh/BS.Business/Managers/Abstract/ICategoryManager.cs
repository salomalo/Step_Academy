using BS.Entities;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface ICategoryManager : IManager
    {
        IEnumerable<Category> GetAll();
    }
}
