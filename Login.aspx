<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InleverOpdracht1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Login</h1>
    <asp:Label ID="LoginPreMsg" runat="server" Text=""></asp:Label>


    <div id="LoginContainer">

        <div class="login-input">
            <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameInput" runat="server"></asp:TextBox>
        </div>

        <div class="login-input">
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordInput" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="LoginMsg" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="LoginButton" runat="server" Text="Log in" OnClick="LoginButton_Click" />

    </div>


</asp:Content>
