<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginPage.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="margin: auto; border: 5px solid white">
                <tr>
                    
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="Register" />
                    </td>
                    <td>
                        <asp:Button ID="buttonLogin" runat="server" TextMode="password" Text="Login" OnClick="buttonLogin_Click" />
                        <asp:Button ID="btnResetPass" runat="server" OnClick="btnResetPass_Click" Text="Reset Password" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Label ID="labelErrorMessage" runat="server" Text="Incorrect credentials"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
