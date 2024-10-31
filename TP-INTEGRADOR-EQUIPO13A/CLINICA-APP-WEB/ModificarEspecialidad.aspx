<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarEspecialidad.aspx.cs" Inherits="CLINICA_APP_WEB.ModificarEspecialidad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contenedor">
 <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
 
 <h1 class="titulo-principal">MODIFICAR ESPECIALIDAD</h1>

 <div class="contenedor-formulario">
     <div class="grupo-formulario">
         
         <label for="txtIDEspecialidad" class="etiqueta-formulario">Id Especialidad:</label>
         <asp:TextBox ID="txtIDEspecialidad" CssClass="entrada-formulario" runat="server" placeholder="ID" Enabled="false"/>

         <label for="txtEspecialidad" class="etiqueta-formulario">Nombre Especialidad:</label>
<asp:TextBox ID="txtEspecialidad" CssClass="entrada-formulario" runat="server" placeholder="Especialidad"/>
         </div>
     <div>
     <asp:Button ID="btnModificarEspecialidad" OnClick="btnModificarEspecialidad_Click" Text="Modificar" CssClass="btn-enviar" runat="server" />
 </div>
     </div>
</asp:Content>
