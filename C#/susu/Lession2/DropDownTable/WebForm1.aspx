<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="DropDownTable.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 520px">
            Количество строк<asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            Количество столбцов<asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
