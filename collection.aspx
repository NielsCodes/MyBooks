<%@ Page Title="Collection" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="collection.aspx.cs" Inherits="InleverOpdracht1.collection" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>My Book collection</h1>

    <div id="book-overview-wrapper">
        <asp:GridView ID="CollectionTable" runat="server" AutoGenerateColumns="False" AllowPaging="true">
            <Columns>
                <%-- Convert image URL into image --%>
                <asp:TemplateField HeaderText="Cover"> 
                    <ItemTemplate>
                        <asp:Image CssClass="book-cover" ImageUrl='<%# Eval("cover") %>' runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title" />
                <asp:BoundField DataField="author" HeaderText="Author" SortExpression="author" />
                <asp:BoundField DataField="genre" HeaderText="Genre" SortExpression="genre" />
                <asp:BoundField DataField="series" HeaderText="Series" SortExpression="series" />
                <asp:BoundField DataField="language" HeaderText="Language" SortExpression="language" />
                <asp:BoundField DataField="releaseDate" HeaderText="Release date" SortExpression="releaseDate" />
                <asp:TemplateField HeaderText="More information">
                    <ItemTemplate>
                        <asp:HyperLink Text="See more &rarr;" NavigateUrl='<%# String.Format("~/Book.aspx?id={0}", Eval("id"))%>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
   </div>
    
</asp:Content>
