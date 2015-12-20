<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_03_VisitCardViewer.Errors.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div>
        <asp:Label ID="lblWhat" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblWhy" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblSuggestion" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
