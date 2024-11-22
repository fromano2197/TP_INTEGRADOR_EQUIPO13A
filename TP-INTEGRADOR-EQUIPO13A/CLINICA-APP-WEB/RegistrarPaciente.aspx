<%@ Page Title="Registro de Paciente" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarPaciente.aspx.cs" Inherits="CLINICA_APP_WEB.RegistrarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />


        <h1 class="titulo-principal">REGISTRARSE</h1>
        <div>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="False"></asp:Label>
        </div>
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
                <label for="txtFechaNac" class="etiqueta-formulario">Fecha de nacimiento:</label>
                <asp:TextBox ID="txtFechaNac" CssClass="entrada-formulario" runat="server" placeholder="Fecha de nacimiento" required="required" TextMode="Date"/>
            </div>
            <div class="grupo-formulario">
                <label for="txtEmail" class="etiqueta-formulario">Correo Electrónico:</label>
                <asp:TextBox ID="txtEmail" CssClass="entrada-formulario" runat="server" placeholder="Correo electrónico" required="required" />
            </div>
            <div class="grupo-formulario">
                <label for="txtTelefono" class="etiqueta-formulario">Telefono:</label>
                <asp:TextBox ID="txtTelefono" CssClass="entrada-formulario" runat="server" placeholder="Telefono" required="required" />
            </div>
            <div class="grupo-formulario">
                <label for="txtDireccion" class="etiqueta-formulario">Direccion:</label>
                <asp:TextBox ID="txtDireccion" CssClass="entrada-formulario" runat="server" placeholder="Direccion" required="required" />
            </div>
            <div class="grupo-formulario">
                <label for="txtUsuario" class="etiqueta-formulario">Usuario:</label>
                <asp:TextBox ID="txtUsuario" CssClass="entrada-formulario" runat="server" placeholder="Usuario" required="required" />
            </div>
            <div class="grupo-formulario">
                <label for="txtPass" class="etiqueta-formulario">Contraseña:</label>
                <asp:TextBox ID="txtPass" TextMode="Password" CssClass="entrada-formulario" runat="server" placeholder="Contraseña" required="required" />
            </div>
            <asp:Button ID="btnRegistrar" Text="Registrarse" CssClass="btn-enviar" OnClick="btnRegistrar_Click" runat="server" />
            <asp:HyperLink CssClass="enlace-formulario" NavigateUrl="Default.aspx" Text="Volver" runat="server"></asp:HyperLink>
        </div>



        <div class="contenedor-enlaces">
            <asp:HyperLink CssClass="enlace-formulario" NavigateUrl="Default.aspx" Text="Ya tengo cuenta, iniciar sesión" runat="server"></asp:HyperLink>
        </div>
    </div>
</asp:Content>
