<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="_03_VisitCardViewer.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Links" runat="server">
    <style>
        .autocomplete_completionListElement {
            margin: 0px!important;
            background-color: inherit;
            color: windowtext;
            border: buttonshadow;
            border-width: 1px;
            border-style: solid;
            overflow: auto;
            height: 200px;
            font-family: Tahoma;
            font-size: small;
            text-align: left;
            list-style-type: none;
        }
        /* AutoComplete highlighted item */
        .autocomplete_highlightedListItem {
            background-color: #ffff99;
            color: black;
            padding: 1px;
        }

        /* AutoComplete item */
        .autocomplete_listItem {
            background-color: window;
            color: windowtext;
            padding: 1px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Scripts" runat="server">
    <script type="text/javascript">
        function show() {
            document.write("<head id='Head1' runat='server'></head>");
        }
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager"></asp:ScriptManager>
    <asp:Button runat="server" Text="Register card" ID="btnRegisterCard" OnClick="btnRegisterCard_Click" />
    <asp:DataGrid runat="server" ID="dgCustomers"></asp:DataGrid>

    <asp:CheckBoxList runat="server" ID="cblCustomers" DataTextField="Name" DataValueField="Id"></asp:CheckBoxList>


    <asp:TextBox runat="server" ID="txtAutocomplete"></asp:TextBox>

    <ajaxToolkit:AutoCompleteExtender
        ID="AutoCompleteExtender"
        TargetControlID="txtAutocomplete"
        runat="server"
        MinimumPrefixLength="2"
        CompletionInterval="1000"
        CompletionSetCount="10"
        ServiceMethod="GetCompletionList"
        CompletionListCssClass="autocomplete_completionListElement"
        CompletionListItemCssClass="autocomplete_listItem"
        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem">
    </ajaxToolkit:AutoCompleteExtender>
    <asp:Button runat="server" ID="btnFilter" OnClick="btnFilter_Click" Text="Filter" />
</asp:Content>
