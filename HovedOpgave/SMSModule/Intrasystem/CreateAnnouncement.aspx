﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Intrasystem/Intra.Master" AutoEventWireup="true" CodeBehind="CreateAnnouncement.aspx.cs" Inherits="SMSModule.Intrasystem.WebForm2" %>
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
            <asp:TextBox ID="txtMessage" runat="server" Height="191px" Width="405px"></asp:TextBox>
        </p>
        <p style="margin-left: 320px">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Målgruppe:"></asp:Label>
        </p>
        <p>
            <asp:Button ID="btnCreate" runat="server" OnClick="btnCreate_Click" Text="Opret meddelelse" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlGroup" runat="server">
            </asp:DropDownList>
        </p>
    </center>

</asp:Content>
