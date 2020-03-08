<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Lession_3._1.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:Label ID="Label1" runat="server" Font-Size="Larger" Text="Авторизация"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Логин"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Font-Size="Large"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Пароль"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Font-Size="Large"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Font-Size="Large" OnClick="Button1_Click" Text="Войти" />
        </div>
    </form>
</body>
</html>
