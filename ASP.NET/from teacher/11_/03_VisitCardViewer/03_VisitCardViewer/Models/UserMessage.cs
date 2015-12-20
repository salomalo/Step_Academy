using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_VisitCardViewer.Models
{
    public class UserMessage
    {
        static UserMessage()
        {
            Messages = new List<UserMessage>();
        }

        public static List<UserMessage> Messages { get; set; }

        public string Message { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
    }
}