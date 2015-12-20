<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SiteBookMarksHolder.AdminPages.UsersPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <%-- List of all users are displayed --%>

    <asp:Button runat="server" Text="Add User" id="btnAddUser" OnClick="btnAddUser_Click" />
    
    <asp:Button runat="server" Text="Delete User" id="btnDeleteUser" OnClick="btnDeleteUser_Click" />

    <asp:Label runat="server" ID="lable" AssociatedControlID="dgUsers">All users</asp:Label>
    <asp:DataGrid runat="server" ID="dgUsers" ></asp:DataGrid>





</asp:Content>
