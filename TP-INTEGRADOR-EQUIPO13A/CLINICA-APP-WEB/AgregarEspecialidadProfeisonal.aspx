<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgregarEspecialidadProfeisonal.aspx.cs" Inherits="CLINICA_APP_WEB.AgregarEspecialidadProfeisonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="contenedor">
<img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
 
<h1 class="titulo-principal">AGREGAR ESPECIALIDAD</h1>

<div class="contenedor-formulario">
    <div class="grupo-formulario">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        <label for="txtEspecialidad" class="etiqueta-formulario">Nombre Especialidad:</label>
        <asp:TextBox ID="txtEspecialidad" CssClass="entrada-formulario" runat="server" placeholder="Especialidad"/>
        </div>
        <div>
    <asp:Button ID="btAgregarEspecialidad" onclick="btAgregarEspecialidad_Click" Text="Agregar Especialidad" CssClass="btn-enviar" runat="server" />
</div>
        </div>
    </div>
        
</asp:Content>
