<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Intrasystem/Intra.Master" AutoEventWireup="true" CodeBehind="CreateAnnouncement.aspx.cs" Inherits="SMSModule.Intrasystem.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentarea" runat="server">
    <center><h1>Opret informationsmeddelelse</h1>
        <p>
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Overskrift:"></asp:Label>
        </p>
        <p>
            &nbsp;<asp:TextBox ID="txtHeader" runat="server" Font-Bold="False" Width="400px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Meddelelse:"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="txtMessage" runat="server" Height="191px" Width="405px" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p style="margin-left: 320px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Målgruppe:"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Opret meddelelse" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlGroup" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Alle</asp:ListItem>
                <asp:ListItem Value="2">Undervisere</asp:ListItem>
                <asp:ListItem Value="3">Forældre</asp:ListItem>
                <asp:ListItem Value="4">Elever</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Du skal indtaste en overskrift." ControlToValidate="txtHeader" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>  
        </p>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du skal indtaste en meddelelse." ControlToValidate="txtMessage" Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </p>
    </center>

</asp:Content>
