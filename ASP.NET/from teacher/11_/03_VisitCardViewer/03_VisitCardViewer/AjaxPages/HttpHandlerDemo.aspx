<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HttpHandlerDemo.aspx.cs" Inherits="_03_VisitCardViewer.AjaxPages.HttpHandlerDemo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/CommonFunctions.js"></script>
    <script type="text/javascript">
        var sendMsgUrl = '<%=ResolveUrl("~/Handlers/AddMessageHandler.ashx") %>';
        var loadMsgsUrl = '<%=ResolveUrl("~/Handlers/MessageListHandler.ashx") %>';
    </script>
    <script type="text/javascript" src="../Scripts/Pages/HttpHandlerDemo.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <input id="btnRefresh" type="button" value="Load" />
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

    <div id="msgContainer">
        Username:
    <input type="text" id="txtUserName" />
        <br />
        Login:
    <input type="text" id="txtLogin" />
        <br />
        Message:
    <textarea id="txtMessage"></textarea><br />

        <input id="btnPostMsg" type="button" value="Post message" />
    </div>
</asp:Content>
