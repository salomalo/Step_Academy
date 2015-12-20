<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterCard.aspx.cs" Inherits="_03_VisitCardViewer.Pages.RegisterCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
    <link rel="stylesheet" type="text/css" href='<%=ResolveUrl("~/Content/Pages/Registration.css") %>' />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div class="registerCardContainer">
        <div class="row">
            <div class="rowTitle">
                Name:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
            </div>
        </div>
         <div class="row">
            <div class="rowTitle">
                Surname:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtSurname"></asp:TextBox>
            </div>
        </div>
         <div class="row">
            <div class="rowTitle">
                Profession:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtProfession"></asp:TextBox>
            </div>
        </div>
         <div class="row">
            <div class="rowTitle">
                Email:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="rowTitle">
                Phone:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtPhone" TextMode="Phone"></asp:TextBox>
            </div>
        </div>
        <asp:Button runat="server" Text="Save" ID="btnSave" OnClick="btnSave_Click" />
        <asp:Button runat="server" Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" />
    </div>

</asp:Content>
