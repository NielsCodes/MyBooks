<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="InleverOpdracht1.Book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="single-book-wrapper">

        <div id="cover-container">
            <asp:Image ID="CoverImage" runat="server"/>
        </div>

        <div id="info-container">
            <h1 id="BookTitle" class="title" runat="server"></h1>
            <h2 id="BookAuthor" class="author" runat="server"></h2>

            <h3>Book info</h3>
            <div id="details-container">

                <div class="book-detail">
                    <span class="category-label">Genre: </span>
                    <span id="BookGenre" runat="server"></span>
                </div>
                
                <div class="book-detail">
                    <span class="category-label">Series: </span>
                    <span id="BookSeries" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Language: </span>
                    <span id="BookLanguage" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Edition: </span>
                    <span id="BookEdition" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Publisher: </span>
                    <span id="BookPublisher" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Pages: </span>
                    <span id="BookPages" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Cover type: </span>
                    <span id="BookCoverType" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">ISBN: </span>
                    <span id="BookISBN" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Release date: </span>
                    <span id="BookReleaseDate" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Price: </span>
                    <span id="BookPrice" runat="server"></span>
                </div>
                
                

            </div>

            <h3>Personal info</h3>
            <div id="personal-details-container">

                <div class="book-detail">
                    <span class="category-label">Purchase date: </span>
                    <span id="BookPurchaseDate" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Purchase price: </span>
                    <span id="BookPurchasePrice" runat="server"></span>
                </div>

                <div class="book-detail">
                    <span class="category-label">Profit / loss: </span>
                    <span id="BookProfit" runat="server"></span>
                </div>

                <asp:Button ID="BookEditButton" runat="server" Text="Edit book" OnClick="BookEditButton_Click" />

            </div>
        </div>

    </div>

    


</asp:Content>
