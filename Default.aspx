<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InleverOpdracht1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main id="search-main">

        <div id="search-wrapper">

            <h1>Search book</h1>

            <div id="search-controls">
                <asp:TextBox ID="SearchQueryInput" runat="server" placeholder="Search by book, author or series"></asp:TextBox>
                <asp:Button ID="ExecuteSearchButton" runat="server" Text="Search" OnClick="ExecuteSearchButton_Click" />
                <asp:Label ID="TestLabel" runat="server"></asp:Label>
            </div>
            
        </div>

    </main>
    
</asp:Content>
