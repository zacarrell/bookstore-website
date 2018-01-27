<%@ Page Title="Sign In to Carrell Books" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Sign In</h1>

    Username<br />
    <asp:TextBox ID="username" runat="server"></asp:TextBox><br /><br />

    Password<br />
    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox><br /><br />

    <asp:Button ID="loginBtn" runat="server" Text="Sign In" OnClick="loginBtn_Click" />

    <asp:Label ID="resultLabel" runat="server" Text="Lbel" CssClass="error"></asp:Label>
</asp:Content>

