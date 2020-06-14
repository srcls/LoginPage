<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="LoginPage.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblSum" runat="server" Text="suma = "></asp:Label>
        </div>
        <asp:Button ID="btnBuy" runat="server" OnClick="btnBuy_Click" Text="Kup" />
    </form>
</body>
</html>
