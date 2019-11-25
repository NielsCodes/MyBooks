<%@ Page Title="Home | MyBooks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InleverOpdracht1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>My Book collection</h1>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." AllowPaging="True" AllowSorting="True">
        <Columns>
            <%-- Convert image URL into image --%>
            <asp:TemplateField HeaderText="Cover" runat="server"> 
                <ItemTemplate>
                    <asp:Image ImageUrl='<%# Eval("cover") %>' runat="server"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
            <asp:BoundField DataField="genre" HeaderText="genre" SortExpression="genre" />
            <asp:BoundField DataField="series" HeaderText="series" SortExpression="series" />
            <asp:BoundField DataField="language" HeaderText="language" SortExpression="language" />
            <%-- <asp:BoundField DataField="edition" HeaderText="edition" SortExpression="edition" /> --%>
            <%-- <asp:BoundField DataField="publisher" HeaderText="publisher" SortExpression="publisher" /> --%>
            <%-- <asp:BoundField DataField="pages" HeaderText="pages" SortExpression="pages" /> --%>
            <%-- <asp:BoundField DataField="coverType" HeaderText="coverType" SortExpression="coverType" /> --%>
            <%-- <asp:BoundField DataField="isbn" HeaderText="isbn" SortExpression="isbn" /> --%>
            <asp:BoundField DataField="releaseDate" HeaderText="releaseDate" SortExpression="releaseDate" />
            <%-- <asp:BoundField DataField="purchaseDate" HeaderText="purchaseDate" SortExpression="purchaseDate" /> --%>
            <%-- <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" /> --%>
            <%-- <asp:BoundField DataField="purchasePrice" HeaderText="purchasePrice" SortExpression="purchasePrice" /> --%>
            <asp:TemplateField HeaderText="More information">
                <ItemTemplate>
                    <asp:HyperLink Text="See more -->" NavigateUrl='<%# String.Format("~/About.aspx?book={0}", Eval("id"))%>' target="_blank" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyBooksConnectionString1 %>" ProviderName="<%$ ConnectionStrings:MyBooksConnectionString1.ProviderName %>" SelectCommand="SELECT [id], [title], [author], [genre], [series], [language], [edition], [publisher], [pages], [cover], [coverType], [isbn], [releaseDate], [purchaseDate], [price], [purchasePrice] FROM [Books]"></asp:SqlDataSource>



</asp:Content>
