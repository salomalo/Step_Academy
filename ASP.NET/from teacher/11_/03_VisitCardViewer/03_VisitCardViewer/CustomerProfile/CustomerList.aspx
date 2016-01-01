﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="_03_VisitCardViewer.CustomerProfile.CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <asp:ObjectDataSource runat="server" ID="odsCustomers"
        SelectMethod="GetAll"
        DeleteMethod="Delete"
        DataObjectTypeName="DataModel.CustomerProfile"
        TypeName="DataAccess.Concrete.DbStore"></asp:ObjectDataSource>

    <%--  <asp:SqlDataSource runat="server" ID="sqldsCustomers"
        SelectCommand="select * from CustomerProfile cp inner join CustomerInfo ci on cp.Id = ci.Id" SelectCommandType="Text"
        DataSourceMode="DataReader" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:defaultConn %>"></asp:SqlDataSource>
    --%>



    <asp:Button runat="server" Text="Add" ID="btnAddCustomer" OnClick="btnAddCustomer_Click" />
    <asp:GridView runat="server" ID="dgCustomers" DataSourceID="odsCustomers" DataKeyNames="Id" AutoGenerateColumns="false" AutoGenerateDeleteButton="false">
        <Columns>
            <asp:BoundField HeaderText="Customer Name" DataField="Name" />
            <asp:BoundField HeaderText="Customer Surname" DataField="Surname" />
            <asp:BoundField HeaderText="Customer Birthday" DataField="Birthday" />
            <asp:BoundField HeaderText="Customer Phone" DataField="Phone" />
            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <span style="color: green">
                        <asp:Label runat="server" Text='<%#Eval("Email") %>'></asp:Label></span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    Operations
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="lnkEdit" runat="server"
                        NavigateUrl='<%#"~/CustomerProfile/EditCustomerProfile.aspx?Id=" + Eval("Id") %>'>Edit</asp:HyperLink>&nbsp;|&nbsp;
                   <asp:LinkButton ID="lbtDelete" CommandName="Delete" runat="server" OnClientClick="return confirm('Are you certain you want to delete this customer?');">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:UpdateProgress runat="server">
        <ProgressTemplate>
            <div style="position:absolute; top:0; bottom:0; left:0; right:0; background-color: white; opacity:.7">
                Loging>>>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label runat="server" ID="lblAddStatus"></asp:Label>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnPostBack" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:Button runat="server" ID="btnPostBack" Text="Click for Postback" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Button runat="server" Text="Add" ID="ajaxAddDumpUser" OnClick="ajaxAddDumpUser_Click" />
            <asp:Button runat="server" Text="Refresh" ID="RefreshGrid" OnClick="RefreshGrid_Click" />
            <asp:GridView runat="server" ID="gvAjaxUsers" DataKeyNames="Id" AutoGenerateColumns="false" AutoGenerateDeleteButton="false">
                <Columns>
                    <asp:BoundField HeaderText="Customer Name" DataField="Name" />
                    <asp:BoundField HeaderText="Customer Surname" DataField="Surname" />
                    <asp:BoundField HeaderText="Customer Birthday" DataField="Birthday" />
                    <asp:BoundField HeaderText="Customer Phone" DataField="Phone" />
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <span style="color: green">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Email") %>'></asp:Label></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Operations
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkEdit" runat="server"
                                NavigateUrl='<%#"~/CustomerProfile/EditCustomerProfile.aspx?Id=" + Eval("Id") %>'>Edit</asp:HyperLink>&nbsp;|&nbsp;
                   <asp:LinkButton ID="lbtDelete" OnClick="lbtDelete_Click" runat="server" OnClientClick="return confirm('Are you certain you want to delete this customer?');">Delete</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>