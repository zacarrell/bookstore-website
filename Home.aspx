<%@ Page Title="Welcome to Carrell Books!" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Welcome to Carrell Books!</h1>
    <p>Home of the best books, both real and fake!</p>
    <p>You can't purchase books from our web site yet, but feel free to browse! You can also <a href="Register.aspx">
       create an account</a> with us, or <a href="SignIn.aspx">sign in</a> if you're already a member.</p>
</asp:Content>

