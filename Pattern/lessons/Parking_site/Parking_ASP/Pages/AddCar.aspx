<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="Parking_ASP.Pages.AddCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="raddCarContainer">
        <div class="row">
            <div class="rowTitle">
                Owner's Name:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
            </div>
        </div>
         <div class="row">
            <div class="rowTitle">
                Owner's Surname:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtSurname"></asp:TextBox>
            </div>
        </div>
         <div class="row">
            <div class="rowTitle">
                Car Model:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtCarModel"></asp:TextBox>
            </div>
        </div>
         <div class="row">
            <div class="rowTitle">
                Car Number:
            </div>
            <div class="inputContainer">
                <asp:TextBox runat="server" ID="txtCarNumber"></asp:TextBox>
            </div>
        </div>
        
        <asp:Button runat="server" Text="Save" ID="btnSave" OnClick="btnSave_Click" />
        <asp:Button runat="server" Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" />
        <asp:Button runat="server" Text="Delete" ID="btnDelete" OnClick="btnDelete_Click" />
    </div>

</asp:Content>
