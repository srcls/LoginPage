<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="LoginPage.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="asd">

            <asp:Label ID="txtProduct" runat="server"></asp:Label>

        </div>
        <asp:DropDownList ID="SortList" runat="server">
            <asp:ListItem Value="PriceDesc">Cena malejaca</asp:ListItem>
            <asp:ListItem Value="PriceAsc">Cena rosnaca</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnSort" runat="server" OnClick="btnSort_Click" Text="Sortuj" />
        <br />
        <asp:TextBox ID="txtFiltr" runat="server"></asp:TextBox>
        <asp:Button ID="btnFiltr" runat="server" OnClick="btnFiltr_Click" Text="Filtruj" />
    </form>
</body>
</html>
