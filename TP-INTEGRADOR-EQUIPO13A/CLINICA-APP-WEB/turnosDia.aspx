<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="turnosDia.aspx.cs" Inherits="CLINICA_APP_WEB.turnosDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvTurnosDia" runat="server" CssClass="table"></asp:GridView>
</asp:Content>
