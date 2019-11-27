<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="InleverOpdracht1.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main id="EditContainer">

        <div id="EditFields">

            <%-- Title --%>
            <label>Title</label>
            <asp:TextBox ID="BookTitleInput" runat="server"></asp:TextBox>

            <%-- Author --%>
            <label>Author</label>
            <asp:TextBox ID="BookAuthorInput" runat="server"></asp:TextBox>

            <%-- Genre --%>
            <label>Genre</label>
            <asp:TextBox ID="BookGenreInput" runat="server"></asp:TextBox>

            <%-- Series --%>
            <label>Series</label>
            <asp:TextBox ID="BookSeriesInput" runat="server"></asp:TextBox>

            <%-- Language --%>
            <label>Language</label>
            <asp:TextBox ID="BookLanguageInput" runat="server"></asp:TextBox>

            <%-- Edition --%>
            <label>Edition</label>
            <asp:TextBox ID="BookEditionInput" runat="server"></asp:TextBox>

            <%-- Publisher --%>
            <label>Publisher</label>
            <asp:TextBox ID="BookPublisherInput" runat="server"></asp:TextBox>

            <%-- Pages --%>
            <label>Pages</label>
            <asp:TextBox ID="BookPagesInput" TextMode="Number" runat="server"></asp:TextBox>

            <%-- Cover --%>
            <label>Cover image (URL)</label>
            <asp:TextBox ID="BookCoverInput" runat="server"></asp:TextBox>

            <%-- Cover Type --%>
            <label>Cover Type</label>
            <asp:TextBox ID="BookCoverTypeInput" runat="server"></asp:TextBox>

            <%-- ISBN --%>
            <label>ISBN</label>
            <asp:TextBox ID="BookISBNInput" runat="server"></asp:TextBox>

            <%-- Release date --%>
            <%-- TODO: Change date format --%>
            <label>Release date</label>
            <asp:TextBox ID="BookReleaseDateInput" TextMode="Date" runat="server"></asp:TextBox>

            <%-- Price --%>
            <label>Price</label>
            <asp:TextBox ID="BookPriceInput" TextMode="Number" runat="server"></asp:TextBox>

            <%-- Purchase date --%>
            <%-- TODO: Change date format --%>
            <label>Purchase date</label>
            <asp:TextBox ID="BookPurchaseDateInput" TextMode="Date" runat="server"></asp:TextBox>

            <%-- Price --%>
            <label>Purchase price</label>
            <asp:TextBox ID="BookPurchasePriceInput" TextMode="Number" runat="server"></asp:TextBox>

        </div>

        <asp:Button ID="SaveBookBtn" runat="server" Text="Save book" OnClick="SaveBookBtn_Click" />

    </main>


</asp:Content>
