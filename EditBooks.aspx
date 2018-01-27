<%@ Page Title="Edit the Carrell Books Collection" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EditBooks.aspx.cs" Inherits="EditBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Edit Our Collection</h1>
    <div id="theEditControls" runat="server">
        Title<br />
        <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
        <br /><br />

        Author<br />
        <asp:TextBox ID="AuthorTextBox" runat="server"></asp:TextBox>
        <br /><br />
        
        Illustrator<br />
        <asp:TextBox ID="IllustratorTextBox" runat="server"></asp:TextBox>
        <br /><br />

        Genre<br />
        <asp:TextBox ID="GenreTextBox" runat="server"></asp:TextBox>
        <br /><br />

        Price<br />
        <asp:TextBox ID="PriceTextBox" runat="server"></asp:TextBox>
        <br /><br />

        Year<br />
        <asp:TextBox ID="YearTextBox" runat="server" TextMode="Number"></asp:TextBox>
        <br /><br />

        ISBN<br />
        <asp:TextBox ID="IsbnTextBox" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="IsbnRegexValidator" runat="server"
            ControlToValidate="IsbnTextBox" ValidationExpression="\d{13}"
            ErrorMessage="ISBN must be 13 digits" CssClass="error"></asp:RegularExpressionValidator>
        <br /><br />

        <asp:Button ID="SearchButton" runat="server" Text="Search By Title" OnClick="SearchButton_Click" />
        <asp:Button ID="SearchByIsbnButton" runat="server" Text="Search By ISBN" OnClick="SearchByIsbnButton_Click" />
        <asp:Button ID="AddBookButton" runat="server" Text="Add Book" OnClick="AddBookButton_Click" />
        <asp:Button ID="RemoveBookButton" runat="server" Text="Remove Book" OnClick="RemoveBookButton_Click" />
    </div>

    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" CssClass="error"></asp:Label>
</asp:Content>

