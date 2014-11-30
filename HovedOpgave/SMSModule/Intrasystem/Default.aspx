<%@ Page Title="Skoleintra" Language="C#" Async="true" MasterPageFile="~/Intrasystem/Intra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SMSModule.Intrasystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentarea" runat="server">
    <h2>Hej <%Session["firstname"].ToString();%> <%Session["lastname"].ToString();%> fra <%Session["selectedclass"].ToString();%></h2>
    <div id="announcements" runat="server">
        
    </div>
</asp:Content>
