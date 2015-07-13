using Entities;
using System.Collections.Generic;

namespace Business.Managers.Abstract
{
    public interface IPackageManager : IManager
    {
        IEnumerable<Packeges> GetAll();
    }
}
