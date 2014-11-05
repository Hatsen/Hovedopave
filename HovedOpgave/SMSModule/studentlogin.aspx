<%@ Page Language="C#" AutoEventWireup="true" CodeFile="studentlogin.aspx.cs" Inherits="studentlogin" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="style/student.css" type="text/css"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 25px;
        }
        .auto-style3 {
            height: 25px;
            width: 93px;
        }
        .auto-style4 {
            width: 93px;
        }
        .auto-style5 {
            width: 93px;
            height: 30px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header id="loginheader">
            <h1 id="bannerTitle">Elevintra</h1>
        </header>
        <section id="login">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
            <asp:Label ID="Label1" runat="server" Text="Brugernavn:"></asp:Label>
                    </td>
                    <td class="auto-style2"><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
            <asp:Label ID="Label2" runat="server" Text="Kodeord:"></asp:Label>
                    </td>
                    <td><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
            <asp:Button ID="btnLogin" runat="server" Text="Log ind" OnClick="btnLogin_Click" />
            
                    </td>
                    <td class="auto-style6"></td>
                </tr>
            </table>
            <asp:Label ID="Label3" runat="server" ForeColor="Red" Text="lblError"></asp:Label>
            <br />  
        </section>
    </form>
</body>
</html>
