<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lession1.WebForm1" %>

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
<body style="height: 707px">
    <form id="form1" runat="server">
        <div class="auto-style1" style="height: 310px; width: auto">
            <br />
            Вычисление площади треугольника<br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="a = "></asp:Label>
            <asp:TextBox ID="legA" runat="server" Font-Size="12pt"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="b = "></asp:Label>
            <asp:TextBox ID="legB" runat="server" Font-Size="12pt"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="c = "></asp:Label>
            <asp:TextBox ID="legC" runat="server" Font-Size="12pt" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="calcButton" runat="server" OnClick="calcButton_Click" Text="Найти площадь" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="s = "></asp:Label>
            <asp:TextBox ID="Decision" runat="server" Font-Size="12pt" OnTextChanged="TextBox4_TextChanged"></asp:TextBox>
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
