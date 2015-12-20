using ClassDBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDBAccess
{
    public abstract class BookmarkHolder
    {
        public abstract void SaveUser(Users user);
        public abstract void SU(string log, string pass);
        public abstract List<Users> UsersList { get; set; }
    }
}