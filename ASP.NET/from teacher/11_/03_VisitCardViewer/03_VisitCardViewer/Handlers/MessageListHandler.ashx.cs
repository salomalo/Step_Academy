using _03_VisitCardViewer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_VisitCardViewer.Handlers
{
    /// <summary>
    /// Summary description for MessageListHandler
    /// </summary>
    public class MessageListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string messages = JsonConvert.SerializeObject(UserMessage.Messages);

            context.Response.Write(messages);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}