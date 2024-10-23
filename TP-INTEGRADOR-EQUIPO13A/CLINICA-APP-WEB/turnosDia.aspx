<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="turnosDia.aspx.cs" Inherits="CLINICA_APP_WEB.turnosDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="table-container">
   <asp:GridView ID="dgvTurnosDia" runat="server" CssClass="table" AutoGenerateColumns="False">
    <Columns>
        
        <asp:BoundField HeaderText="Nombre" />
        <asp:BoundField HeaderText="Apellido" />
        <asp:BoundField HeaderText="Fecha" />
        <asp:BoundField HeaderText="Horario" />
        <asp:BoundField HeaderText="Observaciones            " />
       <%-- <asp:BoundField DataField="APELLIDO" HeaderText="Apellido Paciente" />
        <asp:BoundField DataField="OBSERVACIONES" HeaderText="Observaciones" />--%>
    </Columns>
</asp:GridView>
        </div>

</asp:Content>
