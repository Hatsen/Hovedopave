<%@ Page Language="C#" AutoEventWireup="true" CodeFile="parentlogin.aspx.cs" Inherits="parentlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style/parent.css" type="text/css"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header id="loginheader">
            <h1 id="bannerTitle">Forældreintra</h1>
        </header>
        <section id="login">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
            <asp:Label ID="Label1" runat="server" Text="Brugernavn:"></asp:Label>
                    </td>
                    <td class="auto-style2"><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Label ID="Label2" runat="server" Text="Kodeord:"></asp:Label>
                    </td>
                    <td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
            <asp:Button ID="btnLogin" runat="server" Text="Log ind" />
            
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="lblError"></asp:Label>
            <br />  
        </section>
    </form>
</body>
</html>
