<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CLINICA_APP_WEB.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inicio-contenido">
        <div class="inicio-titulo">
            <h1>Bienvenido a Clínica UTN</h1>
        </div>
        <div class="inicio-botones">
            <a href="LoginPacientes.aspx" class="inicio-btn">Portal de Pacientes</a>
            <a href="LoginMedicos.aspx" class="inicio-btn">Portal de Médicos</a>
            <a href="LoginAdministrador.aspx" class="inicio-btn">Portal Administrador</a>
    </div>
</asp:Content>
