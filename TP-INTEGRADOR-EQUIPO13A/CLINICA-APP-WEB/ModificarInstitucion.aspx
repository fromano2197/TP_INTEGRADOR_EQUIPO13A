<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarInstitucion.aspx.cs" Inherits="CLINICA_APP_WEB.ModificarInstitucion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="contenedor">
 <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
 
 <h1 class="titulo-principal">MODIFICAR INSTITUCION</h1>

    <div class="contenedor-formulario">
        <div class="grupo-formulario">
            <label for="txtNombreInstitucion" class="etiqueta-formulario">Nombre Institucion:</label>
            <asp:TextBox ID="txtNombreInstitucion" CssClass="entrada-formulario" runat="server" placeholder="Nombre Institución" required="required" />
            <label for="txtDireccionInstitucion" class="etiqueta-formulario">Dirección:</label>
            <asp:TextBox ID="txtDireccionInstitucion" CssClass="entrada-formulario" runat="server" placeholder="Dirección Institución" required="required" />

            <label for="txtFechaInstitucion" class="etiqueta-formulario">Fecha Apertura:</label>
            <asp:Textbox ID="txtFechaInstitucion" CssClass="entrada-formulario" runat="server" placeholder="Fecha Apertura" required="required" />


        <asp:Button ID="btModificarInstitucion" onclick="" Text="Modificar Institución" CssClass="btn-enviar" runat="server" />
    </div>
        </div>
         </div>
</asp:Content>
