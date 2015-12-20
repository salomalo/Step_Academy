using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    [ServiceContract]
    public interface IAuth
    {
        [OperationContract]
        string Autorize(string user, string pass);
        [OperationContract]
        string Register(string user, string pass, string firstName, string lastName);
        [OperationContract]
        string CreateMD5(string input);
    }
    public class User
    {
        public String LastName { set; get; }
        public String FirstName { set; get; }
        public String UserName { set; get; }
        public String Token { set; get; }
        public DateTime ExpirienceDate { set; get; }
    }
}
