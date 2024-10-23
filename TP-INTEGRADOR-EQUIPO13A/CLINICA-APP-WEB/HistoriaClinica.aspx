<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HistoriaClinica.aspx.cs" Inherits="CLINICA_APP_WEB.HistoriaClinica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="table-container">
   <asp:GridView ID="dgvTurnosDia" runat="server" CssClass="table" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField HeaderText="Fecha Turno" />
        <asp:BoundField HeaderText="Especialidad" />
        <asp:BoundField HeaderText="Observaciones de turno" />
    </Columns>
</asp:GridView>
        </div>
</asp:Content>
