<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ICallbackDemo.aspx.cs" Inherits="_03_VisitCardViewer.AjaxPages.ICallbackDemo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/CommonFunctions.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager runat="server">
        <Services>
            <asp:ServiceReference Path="~/Services/UserMessageService.asmx" />
        </Services>
    </asp:ScriptManager>
    <script type="text/javascript">
        var asmxServiceProxy = _03_VisitCardViewer.Services.UserMessageService;

        $(function () {
            $("#btnUserMessages").click(function () {
                var user = $("#txtUser").val();
                if (user)
                {
                    CallServer(user, null);
                }
            });

            $("#btnGetAll").click(function () {
                CallServerForAll(null, null);
            });

            $("#btnRemove").click(function () {
                //if (ClientMessages && ClientMessages.length > 0)
                //{
                //    asmxServiceProxy.HelloWorld(ClientMessages.pop(), function (messages) { DrawMessages(messages, "chat", true); });
                //}
                $.ajax({
                    type: 'POST',
                    url: '/Services/UserMessageService.asmx/HelloWorld',
                    dataType: 'json',
                    data: JSON.stringify({ message: ClientMessages.pop() }),
                    contentType: 'application/json; charset=utf-8',
                    success:  function (messages) { DrawMessages(messages, "chat", true); },
                    error: function (error) {
                        console.log(error);
                    }
                });
            });
        });

        var ClientMessages = null;

        function ReceiveAllMessagesData(arg) {
            var messages = JSON.parse(arg);
            ClientMessages = messages;
            DrawMessages(messages, "chat", true);

        }

    </script>
    <input type="text" id="txtUser" />
    <input id="btnGetAll" type="button" value="Get All Messages" />
    <input id="btnUserMessages" type="button" value="Search" />
    <input id="btnRemove" type="button" value="Remove last" />
    
    <table id="chat">
        <thead>
            <tr>
                <th>User</th>
                <th>Login</th>
                <th>Message</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</asp:Content>
