<%@ Page Title="Detalles del Profesional" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallesProfesionales.aspx.cs" Inherits="CLINICA_APP_WEB.DetallesProfesionales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />

        <h1 class="titulo-principal">DETALLES DEL PROFESIONAL</h1>
        <div>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Visible="False"></asp:Label>
        </div>
        
        <div class="contenedor-formulario">
            <!-- Número de Documento -->
            <div class="grupo-formulario">
                <label for="txtDni" class="etiqueta-formulario">Número de documento:</label>
                <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Número de documento" ReadOnly="true" />
            </div>
            
            <!-- Nombre -->
            <div class="grupo-formulario">
                <label for="txtNombre" class="etiqueta-formulario">Nombre:</label>
                <asp:TextBox ID="txtNombre" CssClass="entrada-formulario" runat="server" placeholder="Nombre completo" ReadOnly="true" />
            </div>
            
            <!-- Apellido -->
            <div class="grupo-formulario">
                <label for="txtApellido" class="etiqueta-formulario">Apellido:</label>
                <asp:TextBox ID="txtApellido" CssClass="entrada-formulario" runat="server" placeholder="Apellido completo" ReadOnly="true" />
            </div>
            
            <!-- Fecha de Nacimiento -->
            <div class="grupo-formulario">
                <label for="txtFechaNac" class="etiqueta-formulario">Fecha de nacimiento:</label>
                <asp:TextBox ID="txtFechaNac" CssClass="entrada-formulario" runat="server" placeholder="Fecha de nacimiento" ReadOnly="true" />
            </div>
            
            <!-- Correo Electrónico -->
            <div class="grupo-formulario">
                <label for="txtEmail" class="etiqueta-formulario">Correo Electrónico:</label>
                <asp:TextBox ID="txtEmail" CssClass="entrada-formulario" runat="server" placeholder="Correo electrónico" ReadOnly="true" />
            </div>
            
            <!-- Teléfono -->
            <div class="grupo-formulario">
                <label for="txtTelefono" class="etiqueta-formulario">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" CssClass="entrada-formulario" runat="server" placeholder="Teléfono" ReadOnly="true" />
            </div>
            
            <!-- Dirección -->
            <div class="grupo-formulario">
                <label for="txtDireccion" class="etiqueta-formulario">Dirección:</label>
                <asp:TextBox ID="txtDireccion" CssClass="entrada-formulario" runat="server" placeholder="Dirección" ReadOnly="true" />
            </div>
            
            <!-- Usuario -->
            <div class="grupo-formulario">
                <label for="txtUsuario" class="etiqueta-formulario">Usuario:</label>
                <asp:TextBox ID="txtUsuario" CssClass="entrada-formulario" runat="server" placeholder="Usuario" ReadOnly="true" />
            </div>
            
            <!-- Especialidades -->
            <div class="grupo-formulario">
                <label class="etiqueta-formulario">Especialidades:</label>
                <asp:Label ID="lblEspecialidades" CssClass="entrada-formulario" runat="server" Text="Especialidades del profesional" />
            </div>
        </div>
    </div>
</asp:Content>
