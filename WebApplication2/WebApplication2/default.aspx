﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Firstname" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:GridView ID="Reviews" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
