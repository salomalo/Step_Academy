using _03_VisitCardViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace _03_VisitCardViewer.Services
{
    /// <summary>
    /// Summary description for UserMessageService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class UserMessageService : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod]
        public List<UserMessage> HelloWorld(UserMessage message)
        {
            UserMessage msg = UserMessage.Messages
                .FirstOrDefault(m => m.Login == message.Login
                    && m.Message == message.Message
                    && m.UserName == message.UserName);
            if (msg != default(UserMessage))
            {
                UserMessage.Messages.Remove(msg);
            }
            return UserMessage.Messages;
        }
    }
}
