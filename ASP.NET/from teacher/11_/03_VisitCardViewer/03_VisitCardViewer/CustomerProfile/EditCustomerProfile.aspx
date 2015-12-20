<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCustomerProfile.aspx.cs" Inherits="_03_VisitCardViewer.CustomerProfile.EditCustomerProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <asp:ObjectDataSource runat="server" ID="odsEditCustomer"
        UpdateMethod="EditProfile"
        SelectMethod="GetCustomerById"
        DataObjectTypeName="DataModel.CustomerProfile"
        TypeName="DataAccess.Concrete.DbStore">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" Type="Int32" QueryStringField="Id" DefaultValue="-1" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:FormView runat="server" ID="fvEditCustomer" DefaultMode="Edit" DataKeyNames="Id" DataSourceID="odsEditCustomer">
        <EditItemTemplate>
            <div class="registerCardContainer">
                <div class="row">
                    <div class="rowTitle">
                        Name:
                    </div>
                    <div class="inputContainer">
                        <asp:TextBox runat="server" ID="txtName" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="rowTitle">
                        Surname:
                    </div>
                    <div class="inputContainer">
                        <asp:TextBox runat="server" ID="txtSurname" Text='<%# Bind("Surname") %>'></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="rowTitle">
                        Profession:
                    </div>
                    <div class="inputContainer">
                        <asp:TextBox runat="server" ID="txtProfession" Text='<%# Bind("Profession") %>'></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="rowTitle">
                        Email:
                    </div>
                    <div class="inputContainer">
                        <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" Text='<%# Bind("Email") %>'></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="rowTitle">
                        Phone:
                    </div>
                    <div class="inputContainer">
                        <asp:TextBox runat="server" ID="txtPhone" TextMode="Phone" Text='<%# Bind("Phone") %>'></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="rowTitle">
                        Login:
                    </div>
                    <div class="inputContainer">
                        <asp:TextBox runat="server" ID="txtLogin" Text='<%# Bind("Login") %>'></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="rowTitle">
                        Password:
                    </div>
                    <div class="inputContainer">
                        <asp:TextBox runat="server" ID="txtPassword" Text='<%# Bind("Password") %>'></asp:TextBox>
                    </div>
                </div>

                <div class="row">
                    <div class="rowTitle">
                        Birthday:
                    </div>
                    <div class="inputContainer">
                        <asp:TextBox runat="server" ID="txtBirthday" Text='<%# Bind("Birthday") %>'></asp:TextBox>
                    </div>
                </div>
                <asp:Button runat="server" Text="Save" ID="btnSave" OnClick="btnSave_Click" />
                <asp:Button runat="server" Text="Cancel" ID="btnCancel" OnClick="btnCancel_Click" />
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
