<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPass.aspx.cs" Inherits="LoginPage.ResetPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="Reset" />
        </div>
        <asp:Label ID="labelErrorMessage" runat="server" Text="Incorrect email"></asp:Label>
    </form>
</body>
</html>
