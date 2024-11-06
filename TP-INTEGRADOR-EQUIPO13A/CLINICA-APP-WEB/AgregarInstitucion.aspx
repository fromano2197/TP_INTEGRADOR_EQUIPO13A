<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarInstitucion.aspx.cs" Inherits="CLINICA_APP_WEB.AgregarInstitucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contenedor">
    <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
 
    <h1 class="titulo-principal">AGREGAR INSTITUCION</h1>

    <div class="contenedor-formulario">
        <div class="grupo-formulario">
            <label for="txtNombreInstitucion" class="etiqueta-formulario">Nombre Institucion:</label>
            <asp:TextBox ID="txtNombreInstitucion" CssClass="entrada-formulario" runat="server" placeholder="Nombre Institución" required="required" />

            <label for="txtDireccionInstitucion" class="etiqueta-formulario">Dirección:</label>
            <asp:TextBox ID="txtDireccionInstitucion" CssClass="entrada-formulario" runat="server" placeholder="Dirección Institución" required="required" />

            <label for="txtFechaInstitucion" class="etiqueta-formulario">Fecha Apertura:</label>
            <asp:TextBox ID="txtFechaInstitucion" CssClass="entrada-formulario" runat="server" placeholder="DD/MM/AAAA" required="required" />
            </div>
            <div>
        <asp:Button ID="btAgregarInstitucion" onclick="btAgregarInstitucion_Click" Text="Agregar Institución" CssClass="btn-enviar" runat="server" />
    </div>
        </div>
         </div>


</asp:Content>
