<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="collection.aspx.cs" Inherits="InleverOpdracht1.collection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="collection-container">

        <% foreach (var book in BookCollection)
            { %>

                <div class="collection-item">

                    <img src="<%= book.Cover %>" class="cover" />
                    <div class="title"><%= book.Title %></div>
                    <div class="author"><%= book.Author %></div>
                    <asp:Button ID="SeeBookButton" class="view-btn" runat="server" Text="See more" /> 

                </div>

        <% }; %>

    </div>


</asp:Content>
