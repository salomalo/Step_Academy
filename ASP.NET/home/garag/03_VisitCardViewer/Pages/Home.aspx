<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_03_VisitCardViewer.Pages.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <asp:Button runat="server" Text="Add car" id="btnRegisterCard" OnClick="btnRegisterCard_Click" />
    <asp:Button runat="server" Text="Delete car" id="btnDeleteCard" OnClick="btnDeleteCard_Click" />

    <asp:Label runat="server" ID="lable" AssociatedControlID="dgCustomers">All car on Parking</asp:Label>
    <asp:DataGrid runat="server" ID="dgCustomers"></asp:DataGrid>



<%--    <div class="BaseFunctions">
         <asp:Button runat="server" Text="AllCarsOnParking" ID="btnAllCarOnParking" OnClick="btnAllCarOnParking_Click" />
         <asp:Button runat="server" Text="AddCarOnParking" ID="btnAddOnParking" OnClick="btnAddOnParking_Click" />
         <asp:Button runat="server" Text="DeleteCarFromParking" ID="btnDeleteFromParking" OnClick="btnDeleteFromParking_Click" />
     
    </div>--%>


</asp:Content>
