<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_03_VisitCardViewer.Pages.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <asp:Button runat="server" Text="Register card" id="btnRegisterCard" OnClick="btnRegisterCard_Click" />
    <asp:DataGrid runat="server" ID="dgCustomers"></asp:DataGrid>

</asp:Content>
