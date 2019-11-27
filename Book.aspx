<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="InleverOpdracht1.Book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="single-book-wrapper">

        <div id="cover-container">
            <asp:Image ID="CoverImage" runat="server"/>
        </div>

        <div id="info-container">
            <h1 id="BookTitle" class="title" runat="server"></h1>
            <h2 id="BookAuthor" class="author" runat="server"></h2>

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
                    <span class="category-label">Publisher: </span>
                    <span id="BookPublisher" runat="server"></span>
                </div>
                
                

            </div>
        </div>

    </div>

    


</asp:Content>
