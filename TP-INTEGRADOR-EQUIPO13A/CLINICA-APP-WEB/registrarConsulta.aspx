<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="registrarConsulta.aspx.cs" Inherits="CLINICA_APP_WEB.registrarConsulta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="titulo-principal">Registrar Observaciones</h1>
        <div class="contenedor-formulario">
        <div class="grupo-formulario">
            <label for="txtDni" class="etiqueta-formulario">DNI Paciente:</label>
            <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" ReadOnly="true" />
        </div>
        <div class="grupo-formulario">
            <label for="txtNombrePaciente" class="etiqueta-formulario">Nombre Paciente:</label>
            <asp:TextBox ID="txtNombrePaciente" CssClass="entrada-formulario" runat="server" placeholder="Nombre completo" ReadOnly="true" />
        </div>
        <div class="grupo-formulario">
            <label for="txtApellidoPaciente" class="etiqueta-formulario">Apellido Paciente:</label>
            <asp:TextBox ID="txtApellidoPaciente" CssClass="entrada-formulario" runat="server" placeholder="Apellido completo" ReadOnly="true" />
        </div>
        <div class="grupo-formulario">
            <label for="txtAreaObservacionesConsulta" Class="etiqueta-formulario">Observaciones de la Consulta:</label>
            <textarea id="TxtAreaObservacionesConsulta" class="textarea-observaciones" cols="20" rows="2" placeholder="Observaciones..." runat="server"></textarea><%--<asp:Textarea ID="txtObservacionesConsulta" CssClass="formulario-observaciones" runat="server" placeholder="Observaciones.." required="required" />--%>
        </div>

    <asp:Button ID="btnRegistrarConsulta" Text="Registrar Consulta" OnClick="btnRegistrarConsulta_Click" CssClass="btn-enviar" runat="server" />
           </div>

      
        
     

   

</asp:Content>
