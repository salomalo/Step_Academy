using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDBModel
{
    public class HolderContext
    {
       // private static BookmarksHolderEntities ctx = BookmarksHolderEntities.Instance;
             
        public static List<Users> ListUsers;

        //public static void Save(string login, string password)
        //{
        //    using (ctx)
        //    {
        //        var user = new Users
        //        {
        //            UserLogin = login,
        //            UserPassword = password
        //        };

        //        ctx.Users.Add(user);
        //        ctx.SaveChanges();
        //    }
        //}

        public DbSet<Users> _users { get; set; }

       // public static List<Users> res = null;

        //public static List<Users> GetUsers()
        //{
            //using (ctx)
            //{
            //    foreach (Users u in ctx.Users)
            //    {
            //        res.Add(u);
            //    }
            //    return res;
            //}
        //}


    }
}