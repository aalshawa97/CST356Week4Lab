﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Background.aspx.cs" Inherits="Lab4WebApplication.Background" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body
        {
            background-color:wheat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url('Images/oregonSomaliBravanessComunity.jpg'); height: 360px;">
        </div>
        <table style="margin:auto;border:5px solid white"></table>
        <asp:Label ID="txtUserName" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" BackColor="Transparent"></asp:TextBox>
        <p>
            <asp:Label ID="txtPassword" runat="server" Text="Password:" TextMode="Password"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
&nbsp;<asp:Button ID="btnLogin" runat="server" style="margin-bottom: 0px" Text="Login" OnClick="btnLogin_Click" />
        </p>
        <p>
            <asp:Button ID="btnForgotPassword" runat="server" style="margin-bottom: 0px" Text="Forgot password" />
        </p>
        <asp:Label ID="lblErrorMessage" runat="server" Text="Incorrect input!" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
