<%@ Page Title="Administrar Turnos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarTurnos.aspx.cs" Inherits="CLINICA_APP_WEB.AdministrarTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="form-container">
        <h2>Agregar Turnos</h2>
        <asp:Label ID="lblIdTurno" runat="server" Text="ID Turno (solo para modificar)" Visible="false"></asp:Label>
        <asp:TextBox ID="txtIdTurno" runat="server" Visible="false"></asp:TextBox><br />

        <asp:Label ID="lblProfesional" runat="server" Text="Profesional:"></asp:Label>
        <asp:DropDownList ID="ddlProfesionales" runat="server"></asp:DropDownList><br />

        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
        <asp:DropDownList ID="ddlEspecialidades" runat="server"></asp:DropDownList><br />

        <asp:Label ID="lblInstitucion" runat="server" Text="Institución:"></asp:Label>
        <asp:DropDownList ID="ddlInstituciones" runat="server"></asp:DropDownList><br />

        <asp:Label ID="lblFecha" runat="server" Text="Fecha:"></asp:Label>
        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox><br />

        <asp:Label ID="lblHora" runat="server" Text="Hora:"></asp:Label>
        <asp:TextBox ID="txtHora" runat="server" TextMode="Time"></asp:TextBox><br />


        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Turno" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
    </div>


</asp:Content>
