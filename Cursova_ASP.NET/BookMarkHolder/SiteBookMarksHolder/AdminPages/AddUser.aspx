<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="SiteBookMarksHolder.AdminPages.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="UserContainer">
        <div class="row">
            <div class="rowTitle">
                User's Login:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtLogin"></asp:TextBox>
            </div>
        </div>
         <div class="row">
            <div class="rowTitle">
                User's Passwords:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtPassword"></asp:TextBox>
            </div>
        </div>
         
        <asp:Button runat="server" Text="Save" ID="btnSave" OnClick="btnSave_Click" />

        <asp:Button runat="server" Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" />
      <%--  <asp:Button runat="server" Text="Delete" ID="btnDelete" OnClick="btnDelete_Click" />--%>

    </div>
</asp:Content>
