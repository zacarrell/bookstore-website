<%@ Page Title="Register for Carrell Books" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Register</h1>

    User name *<br />
    <asp:TextBox ID="username" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="UsernameRequiredValidator" runat="server" ErrorMessage="You must enter a user name."
        ControlToValidate="username" CssClass="error"></asp:RequiredFieldValidator>
    <br /><br />

    Password *<br />
    <asp:TextBox ID="passwd" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server" ErrorMessage="You must enter a password."
        ControlToValidate="passwd" CssClass="error"></asp:RequiredFieldValidator>
    <br /><br />

    <asp:CheckBox ID="adminRights" runat="server" Text="Doest thou desire administrative rights?" /><br /><br />

    <asp:Button ID="registerBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />

    <asp:Label ID="resultsLabel" runat="server" Text="Label" ForeColor="Red" CssClass="error"></asp:Label>
</asp:Content>

