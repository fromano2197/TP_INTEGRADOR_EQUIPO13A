<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContraseñaOlvidada.aspx.cs" Inherits="CLINICA_APP_WEB.ContraseñaOlvidada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
     
        <h1 class="titulo-principal">Recuperar contraseña</h1>

        <div class="contenedor-formulario">
            <div class="grupo-formulario">
                <label for="numero-documento" class="etiqueta-formulario">Número de documento:</label>
                <div>
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="False"></asp:Label>

                    <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Ingrese su DNI" />
                </div>
                
            </div>
            <div>
                <br />
                <asp:Button ID="btnRecuperar" Text="Recuperar contraseña" CssClass="btn-enviar" runat="server" OnClick="btnRecuperar_Click" />
            </div>
            <div>
                <br />
                <asp:Button ID="btnVolver" Text="Volver" CssClass="btn-enviar" runat="server" OnClick="btnVolver_Click"/>
            </div>
            
        </div>

        
    </div>
</asp:Content>

