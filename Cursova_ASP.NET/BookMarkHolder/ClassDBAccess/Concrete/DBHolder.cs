using ClassDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDBAccess.Concrete
{
    public class DBHolder : BookmarkHolder
    {
        private  BookmarksHolderEntities ctx = BookmarksHolderEntities.Instance;

        public List<Users> GetAll()
        {
            return UsersList;
        }//

        public override void SaveUser(Users user)
        {
            ctx.Users.Add(user);
            ctx.SaveChanges();
        }

        public override void SU(string log, string pass)
        {
                var us = new Users
                {
                    UserLogin = log,
                    UserPassword = pass
                };
                ctx.Users.Add(us);
                ctx.SaveChanges();
        }

        public override List<Users> UsersList
        {
            get
            {
                return ctx.Users.ToList();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}