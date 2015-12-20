<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Parking.Pages.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <asp:Button runat="server" Text="Add car" id="btnAddCar" OnClick="btnAddCar_Click" />
    <asp:Button runat="server" Text="Delete car" id="btnDeleteCar" OnClick="btnDeleteCar_Click" />

    <asp:Label runat="server" ID="lable" AssociatedControlID="dgCustomers">All car on Parking</asp:Label>
    <asp:DataGrid runat="server" ID="dgCustomers" ></asp:DataGrid>

</asp:Content>

