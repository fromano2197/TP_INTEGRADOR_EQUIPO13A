<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarInstitucionProfesional.aspx.cs" Inherits="CLINICA_APP_WEB.AgregarInstitucionProfesional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contenedor">
<img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
 
<h1 class="titulo-principal">AGREGAR INSTITUCION</h1>

<div class="contenedor-formulario">
    <div class="grupo-formulario">
        <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
        <label for="txtNombreInstitucion" class="etiqueta-formulario">Nombre Institucion:</label>
        <asp:TextBox ID="txtNombreInstitucion" CssClass="entrada-formulario" runat="server" placeholder="Nombre Institución" required="required" />
        <div>
    <asp:Button ID="btAgregarInstitucion" onclick="btAgregarInstitucion_Click" Text="Agregar Institución" CssClass="btn-enviar" runat="server" />
</div>
    </div>
    </div>
     </div>
</asp:Content>
