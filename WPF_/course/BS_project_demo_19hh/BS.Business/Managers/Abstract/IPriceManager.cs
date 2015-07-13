using BS.Entities;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IPriceManager : IManager
    {
        IEnumerable<Price> GetAll();
    }
}
