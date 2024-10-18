<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisDatos.aspx.cs" Inherits="CLINICA_APP_WEB.MisDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="contenedor">
     <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
  
     <h1 class="titulo-principal">MIS DATOS</h1>

     <div class="contenedor-formulario">
         <div class="grupo-formulario">
             <label for="txtDni" class="etiqueta-formulario">Número de documento:</label>
             <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Número de documento" required="required" />
         </div>
         <div class="grupo-formulario">
             <label for="txtNombre" class="etiqueta-formulario">Nombre:</label>
             <asp:TextBox ID="txtNombre" CssClass="entrada-formulario" runat="server" placeholder="Nombre completo" required="required" />
         </div>
         <div class="grupo-formulario">
             <label for="txtApellido" class="etiqueta-formulario">Apellido:</label>
             <asp:TextBox ID="txtApellido" CssClass="entrada-formulario" runat="server" placeholder="Apellido completo" required="required" />
         </div>
         <div class="grupo-formulario">
             <label for="txtEmail" class="etiqueta-formulario">Correo Electrónico:</label>
             <asp:TextBox ID="txtEmail" CssClass="entrada-formulario" runat="server" placeholder="Correo electrónico" required="required" />
         </div>
         <div class="grupo-formulario">
             <label for="txtPass" class="etiqueta-formulario">Contraseña:</label>
             <asp:TextBox ID="txtPass" TextMode="Password" CssClass="entrada-formulario" runat="server" placeholder="Contraseña" required="required" />
         </div>
         <asp:Button ID="btnGuardarDatos" Text="Guardar Datos" CssClass="btn-enviar" runat="server" />
     </div>


 </div>
</asp:Content>
