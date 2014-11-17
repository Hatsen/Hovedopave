<%@ Page Title="" Language="C#" MasterPageFile="~/Intrasystem/Intra.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SMSModule.Intrasystem.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentarea" runat="server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Din nuværende adgangskode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOldPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Din ønskede adgangskode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNewPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Gentag ønsket adgangskode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPass" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Skift adgangskode" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
