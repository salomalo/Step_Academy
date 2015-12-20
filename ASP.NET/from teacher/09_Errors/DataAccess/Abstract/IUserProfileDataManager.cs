using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserProfileDataManager
    {
        bool IsValid(string login, string password); 
        string[] GetUserRoles(string login);
    }
}
