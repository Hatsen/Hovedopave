<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/Intrasystem/Intra.Master" AutoEventWireup="true" CodeBehind="ChangeDetails.aspx.cs" Inherits="SMSModule.Intrasystem.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 85%;
    }
        .auto-style2 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentarea" runat="server">
    <br />
    <table class="auto-style1" align="center">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="By:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Adresse:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Telefonnummer:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="E-mail:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnSubmit" runat="server" Text="Rediger oplysninger" OnClick="btnSubmit_Click1" />
            </td>
            <td class="auto-style2"></td>
        </tr>
    </table>
<br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCity" ErrorMessage="Du skal indtaste en by." ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress" ErrorMessage="Du skal indtaste en adresse." ForeColor="Red"></asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPhone" ErrorMessage="Du skal indraste et gyldigt telefonnummer." ForeColor="Red" ValidationExpression="^[2-9]\d{7}$"></asp:RegularExpressionValidator>
<br />
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Du skal indtaste en gyldig e-mail." ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" ForeColor="Red"></asp:RegularExpressionValidator>
</asp:Content>
