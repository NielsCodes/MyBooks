<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="InleverOpdracht1.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1>Manage data</h1>
    <asp:LinkButton ID="ManageAuthorsLink" runat="server" OnClick="ManageAuthorsLink_OnClick">Manage authors</asp:LinkButton>
    <br />
    <asp:LinkButton ID="ManageSeriesLink" runat="server" OnClick="ManageSeriesLink_OnClick">Manage series</asp:LinkButton>
    <br />
    <asp:LinkButton ID="ManageGenresLink" runat="server" OnClick="ManageGenresLink_OnClick">Manage genres</asp:LinkButton>
    <br />
    <asp:LinkButton ID="ManageLanguagesLink" runat="server" OnClick="ManageLanguagesLink_OnClick">Manage languages</asp:LinkButton>
    <br />
    <asp:LinkButton ID="ManagePublishersLink" runat="server" OnClick="ManagePublishersLink_OnClick">Manage publishers</asp:LinkButton>
    <br />
    <asp:LinkButton ID="ManageCoverTypesLink" runat="server" OnClick="ManageCoverTypesLink_OnClick">Manage cover types</asp:LinkButton>

</asp:Content>
