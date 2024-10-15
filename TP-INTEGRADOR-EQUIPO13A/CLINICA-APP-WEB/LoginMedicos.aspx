<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginMedicos.aspx.cs" Inherits="CLINICA_APP_WEB.LoginMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
     
        <h1 class="titulo-principal">CLÍNICA UTN</h1>

        <div class="contenedor-formulario">
            <div class="grupo-formulario">
                <label for="numero-documento" class="etiqueta-formulario">Número de documento:</label>
                <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Número de documento" required="required" />
            </div>
            <div class="grupo-formulario">
                <label for="password" class="etiqueta-formulario">Contraseña:</label>
                <asp:TextBox ID="txtPass" TextMode="Password" CssClass="entrada-formulario" runat="server" placeholder="Contraseña" required="required" />
            </div>
            <asp:Button ID="btnLogin" Text="Iniciar Sesión" CssClass="btn-enviar" runat="server" />
        </div>

        <div class="contenedor-enlaces">
            <asp:HyperLink CssClass="enlace-formulario" NavigateUrl="#" Text="Olvidé mi contraseña" runat="server"></asp:HyperLink>
            <br />
            <asp:HyperLink CssClass="enlace-formulario" NavigateUrl="#" Text="Registrarse" runat="server"></asp:HyperLink>
        </div>
    </div>
</asp:Content>
