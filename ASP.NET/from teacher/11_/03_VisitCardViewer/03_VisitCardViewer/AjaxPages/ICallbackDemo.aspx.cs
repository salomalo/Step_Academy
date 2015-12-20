using _03_VisitCardViewer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_VisitCardViewer.AjaxPages
{
    public partial class ICallbackDemo : System.Web.UI.Page, ICallbackEventHandler
    {

        protected String returnValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Search
            String cbReference = Page.ClientScript.GetCallbackEventReference(this,
            "arg", "ReceiveServerData", "context");

            String callbackScript = "function CallServer(arg, context)" +
                "{ " + cbReference + ";}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                "CallServer", callbackScript, true);

            //For Sasha: not a callback use
            //just adding another js function :)
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ReceiveServerData", @"function ReceiveServerData(args)
        { var a = " + 4444.ToString() +/* you could be surprised but you definitely can use string concatenation here, 
                                        * so you can pass some parameters into the function's body*/ @"
            var messages = JSON.parse(args);
           DrawMessages(messages, 'chat', true);
        }", true);
            #endregion
            //-------------------------------------------------------------------
            #region Get All Messages
            var control = new AllMessagesSender();
            Page.Controls.Add(control);

            String cbAllMsgsReference = Page.ClientScript.GetCallbackEventReference(control,
            "arg", "ReceiveAllMessagesData", "context");

            String callbackAllMessagesScript = "function CallServerForAll(arg, context)" +
               "{ " + cbAllMsgsReference + ";}";

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                "CallServerForAll", callbackAllMessagesScript, true);
            #endregion

            Page.ClientScript.RegisterStartupScript(this.GetType(), "OnStartup", "CallServerForAll()", true);
        }

        public string GetCallbackResult()
        {
            return returnValue;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            returnValue = JsonConvert.SerializeObject(UserMessage.Messages.Where(m => m.UserName == eventArgument.Trim()));
        }
    }

    public class AllMessagesSender : Control, ICallbackEventHandler
    {

        protected String returnValue;

        public string GetCallbackResult()
        {
            return returnValue;
        }

        public void RaiseCallbackEvent(string eventArgument)
        {
            returnValue = JsonConvert.SerializeObject(UserMessage.Messages);
        }
    }
}