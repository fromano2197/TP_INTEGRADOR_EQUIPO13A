<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BuscarPaciente.aspx.cs" Inherits="CLINICA_APP_WEB.BuscarPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
        <h1 class="titulo-principal">CLÍNICA UTN</h1>

        <div class="contenedor-formulario">
            <div class="grupo-formulario">
                <label for="txtDni" class="etiqueta-formulario">INGRESE DNI:</label>
                <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="DNI" required="required" />
            </div>
            <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" Text="Buscar Paciente" CssClass="btn-enviar" runat="server" />
        </div>

        <div class="contenedor-datos-paciente" style="margin-top: 20px;">
            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje-error" />
            <div class="datos-paciente">
                <p><strong>Nombre:</strong> <asp:Label ID="lblNombre" runat="server" /></p>
                <p><strong>Apellido:</strong> <asp:Label ID="lblApellido" runat="server" /></p>
                <p><strong>DNI:</strong> <asp:Label ID="lblDni" runat="server" /></p>
            </div>
        </div>
    </div>
</asp:Content>