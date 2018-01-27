<%@ Page Title="Browse Carrell Books" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="browse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Our Book Collection</h1>
    <asp:GridView ID="BooksGridView" runat="server"></asp:GridView>
</asp:Content>

