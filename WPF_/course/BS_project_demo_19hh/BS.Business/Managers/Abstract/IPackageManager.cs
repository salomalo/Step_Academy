using BS.Entities;
using System.Collections.Generic;

namespace BS.Business.Managers.Abstract
{
    public interface IPackageManager : IManager
    {
        IEnumerable<Package> GetAll();
    }
}
