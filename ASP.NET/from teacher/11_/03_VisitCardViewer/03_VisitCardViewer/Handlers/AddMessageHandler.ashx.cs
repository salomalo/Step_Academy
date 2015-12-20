using _03_VisitCardViewer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace _03_VisitCardViewer.Handlers
{
    /// <summary>
    /// Summary description for AddMessageHandler
    /// </summary>
    public class AddMessageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            StreamReader reader = new StreamReader(context.Request.InputStream);
            string str = reader.ReadToEnd();
            var msg = JsonConvert.DeserializeObject<UserMessage>(str);

            UserMessage.Messages.Add(msg);

            context.Response.ContentType = "text/plain";
            context.Response.Write("OK");
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