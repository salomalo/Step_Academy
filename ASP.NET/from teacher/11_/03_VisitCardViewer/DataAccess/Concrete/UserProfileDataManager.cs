using DataAccess.Abstract;
using DataModel;
using DataModel.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserProfileDataManager : IUserProfileDataManager
    {
        private VisitCardDbContext ctx = VisitCardDbContext.Instance;

        public bool IsValid(string login, string password)
        {
            var user = ctx.CustomerProfiles.FirstOrDefault(c => c.Password == password && c.Login == login);
            return user != default(CustomerProfile);
        }

        public string[] GetUserRoles(string login)
        {
            var user = ctx.CustomerProfiles.FirstOrDefault(c => c.Login == login);
            return new String[] { Enum.GetName(typeof(Roles), user.Role )};
        }

        
    }
}
