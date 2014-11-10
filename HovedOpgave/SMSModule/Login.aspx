<%@ Page Language="C#" Async="true"  AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SMSModule.Login" %>

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
            <h1 id="bannerTitle">Skolelogin</h1>
        </header>
        <section id="login">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">
            <asp:Label ID="Label1" runat="server" Text="Brugernavn:"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
            <asp:Label ID="Label2" runat="server" Text="Kodeord:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log ind" />
            
                    </td>
                    <td class="auto-style6"></td>
                </tr>
            </table>
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            <br />  
        </section>
    </form>
</body>
</html>
