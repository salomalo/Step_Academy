<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_02_EmptyProject.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Styles" runat="server">
    <link rel="stylesheet" href='<%= ResolveUrl("~/Content/Pages/Home/Home.css") %>' />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript" src='<%=ResolveUrl("~/Scripts/Main.js") %>'></script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Body" runat="server">
    <script type="text/javascript">
        var myTextBox = '<%= tbId.ClientID %>';
    </script>
    <asp:TextBox runat="server" ID="tbId" Text="My Text box"></asp:TextBox>
    <span id="greeting" runat="server"></span>
    <% 
        string name = GetName();
        
        if (name.Length > 4)
        {%>
    Hello, world!!!!
    <%}
        else
        { %>
    Hello!
    <%} %>


    <script type="text/javascript">
        alert(myTextBox);
    </script>
</asp:Content>
