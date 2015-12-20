using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_VisitCardViewer.Errors
{
    public partial class Default : System.Web.UI.Page
    {
        private class ErrorDetails
        {
            public string What { get; set; }
            public string Why { get; set; }
            public string Suggestion { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Exception error = Server.GetLastError();
            ErrorDetails errorDetails = GetErrorDetails(GetExceptionCause(error));
            DisplayErrorDetails(errorDetails);
            Server.ClearError();
        }

        private void DisplayErrorDetails(ErrorDetails errorDetails)
        {
            lblWhat.Text = errorDetails.What;
            lblWhy.Text = errorDetails.Why;
            lblSuggestion.Text = errorDetails.Suggestion;
        }

        private Exception GetExceptionCause(Exception error)
        {
            while (error.InnerException != null)
            {
                error = error.InnerException;
            }
            return error;
        }

        private ErrorDetails GetErrorDetails(Exception error)
        {
            ErrorDetails errorDetails = new ErrorDetails();
            if (error is HttpException && (error as HttpException).GetHttpCode() == 404)
            {
                errorDetails.What = "Requested resource could not be found";
                errorDetails.Why = "Specified url is incorrect.";
                errorDetails.Suggestion = "Check the specified url.";
            }
            else if (error is SqlException)
            {
                errorDetails.What = "Accessing Database Failed";
                errorDetails.Why = "Could not established connection with database";
                errorDetails.Suggestion = "Report problem to the system administrator";
            }
            else
            {
                errorDetails.What = error.Message;// "Unexpected Error";
            }
            return errorDetails;
        }
    }
}