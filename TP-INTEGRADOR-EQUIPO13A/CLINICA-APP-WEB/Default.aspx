<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CLINICA_APP_WEB.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
    <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
 
    <h1 class="titulo-principal">CLÍNICA UTN</h1>

    <div class="contenedor-formulario">
        <div class="grupo-formulario">
            <label for="usuario" class="etiqueta-formulario">Usuario:</label>
            <asp:TextBox ID="txtUsuario" CssClass="entrada-formulario" runat="server" placeholder="Usuario" required="required" />
        </div>
        <div class="grupo-formulario">
            <label for="password" class="etiqueta-formulario">Contraseña:</label>
            <asp:TextBox ID="txtPass" TextMode="Password" CssClass="entrada-formulario" runat="server" placeholder="Contraseña" required="required" />
        </div>
        <asp:Button ID="btnLogin" OnClick="btnLogin_Click" Text="Iniciar Sesión" CssClass="btn-enviar" runat="server" />
    </div>

    <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje-error" Visible="false"></asp:Label>

    <div class="contenedor-enlaces">
        <asp:HyperLink CssClass="enlace-formulario" NavigateUrl="ContraseñaOlvidada.aspx" Text="Olvidé mi contraseña" runat="server"></asp:HyperLink>
        <br />
        <asp:HyperLink CssClass="enlace-formulario" NavigateUrl="RegistrarPaciente.aspx" Text="Registrarse" runat="server"></asp:HyperLink>
    </div>
</div>
</asp:Content>
