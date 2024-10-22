<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BuscarProfesional.aspx.cs" Inherits="CLINICA_APP_WEB.BuscarProfesional" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="contenedor">
    <img src="./Images/logo.png" alt="Logo de la Clínica UTN" class="logo" />
 
    <h1 class="titulo-principal">CLÍNICA UTN</h1>

    <div class="contenedor-formulario">
       
        <div class="grupo-formulario">
            <label for="password" class="etiqueta-formulario">INGRESE DNI:</label>
            <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="DNI" required="required" />
        </div>
        <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" Text="Buscar Profesional" CssClass="btn-enviar" runat="server" />
    </div>

   
</div>

</asp:Content>
