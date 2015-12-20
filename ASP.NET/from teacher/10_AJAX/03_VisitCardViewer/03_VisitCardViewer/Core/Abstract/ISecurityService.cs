using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_VisitCardViewer.Core.Abstract
{
    public interface ISecurityService
    {
        bool Login(string login, string password, bool remember = false);
        void RefreshPrincipal();
        void Logout();
    }
}
