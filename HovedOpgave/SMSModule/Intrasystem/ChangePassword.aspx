<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Intrasystem/Intra.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SMSModule.Intrasystem.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentarea" runat="server">
    <div id="changePasswordArea" runat="server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Din nuværende adgangskode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtOldPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Din ønskede adgangskode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Gentag ønsket adgangskode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Skift adgangskode" />
                <br />
            </td>
        </tr>
    </table>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="txtNewPass" ErrorMessage="Den nye adgangskode skal være mellem 8 til 50 karakterer lang." ValidationExpression="^.{8,50}$"></asp:RegularExpressionValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="Red" ControlToValidate="txtConfirmPass" ErrorMessage="Den nye adgangskode skal være mellem 8 til 50 karakterer lang." ValidationExpression="^.{8,50}$"></asp:RegularExpressionValidator>
    <br />
        </div>
    </asp:Content>
