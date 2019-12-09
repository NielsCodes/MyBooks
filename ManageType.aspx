<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageType.aspx.cs" Inherits="InleverOpdracht1.ManageType" %>
<%@ Import Namespace="System.Activities.Statements" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="InleverOpdracht1.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <main id="manageContainer">
        <h1>
            <asp:Label runat="server" ID="ManageTitle"></asp:Label>
        </h1>

        <asp:GridView ID="MetaGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="AuthorsDataSource" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="Name" SortExpression="name" />
            </Columns>
        </asp:GridView>
    </main>

    
    <%-- DATA SOURCE ASSIGNED FROM URL PARAM--%>
    <asp:SqlDataSource ID="AuthorsDataSource" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:MyBooksConnectionString1 %>" 
                       DeleteCommand="DELETE FROM [Authors] WHERE [id] = @id" 
                       InsertCommand="INSERT INTO [Authors] ([name]) VALUES (@name)"
                       ProviderName="<%$ ConnectionStrings:MyBooksConnectionString1.ProviderName %>" 
                       SelectCommand="SELECT [id], [name] FROM [Authors]" 
                       UpdateCommand="UPDATE [Authors] SET [name] = @name WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    

    <asp:SqlDataSource ID="GenresDataSource" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:MyBooksConnectionString1 %>" 
                       DeleteCommand="DELETE FROM [Genres] WHERE [id] = @id" 
                       InsertCommand="INSERT INTO [Genres] ([name]) VALUES (@name)"
                       ProviderName="<%$ ConnectionStrings:MyBooksConnectionString1.ProviderName %>" 
                       SelectCommand="SELECT [id], [name] FROM [Genres]" 
                       UpdateCommand="UPDATE [Genres] SET [name] = @name WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    

    <asp:SqlDataSource ID="PublishersDataSource" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:MyBooksConnectionString1 %>" 
                       DeleteCommand="DELETE FROM [Publishers] WHERE [id] = @id" 
                       InsertCommand="INSERT INTO [Publishers] ([name]) VALUES (@name)"
                       ProviderName="<%$ ConnectionStrings:MyBooksConnectionString1.ProviderName %>" 
                       SelectCommand="SELECT [id], [name] FROM [Publishers]" 
                       UpdateCommand="UPDATE [Publishers] SET [name] = @name WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    
    
    <asp:SqlDataSource ID="SeriesDataSource" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:MyBooksConnectionString1 %>" 
                       DeleteCommand="DELETE FROM [Series] WHERE [id] = @id" 
                       InsertCommand="INSERT INTO [Series] ([name]) VALUES (@name)"
                       ProviderName="<%$ ConnectionStrings:MyBooksConnectionString1.ProviderName %>" 
                       SelectCommand="SELECT [id], [name] FROM [Series]" 
                       UpdateCommand="UPDATE [Series] SET [name] = @name WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    
    
    <asp:SqlDataSource ID="LanguagesDataSource" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:MyBooksConnectionString1 %>" 
                       DeleteCommand="DELETE FROM [Languages] WHERE [id] = @id" 
                       InsertCommand="INSERT INTO [Languages] ([name]) VALUES (@name)"
                       ProviderName="<%$ ConnectionStrings:MyBooksConnectionString1.ProviderName %>" 
                       SelectCommand="SELECT [id], [name] FROM [Languages]" 
                       UpdateCommand="UPDATE [Languages] SET [name] = @name WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    

    <asp:SqlDataSource ID="CoverTypesDataSource" runat="server" 
                       ConnectionString="<%$ ConnectionStrings:MyBooksConnectionString1 %>" 
                       DeleteCommand="DELETE FROM [CoverTypes] WHERE [id] = @id" 
                       InsertCommand="INSERT INTO [CoverTypes] ([name]) VALUES (@name)"
                       ProviderName="<%$ ConnectionStrings:MyBooksConnectionString1.ProviderName %>" 
                       SelectCommand="SELECT [id], [name] FROM [CoverTypes]" 
                       UpdateCommand="UPDATE [CoverTypes] SET [name] = @name WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="name" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>


    
    
    
</asp:Content>
