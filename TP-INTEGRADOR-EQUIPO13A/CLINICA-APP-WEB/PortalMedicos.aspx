<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PortalMedicos.aspx.cs" Inherits="CLINICA_APP_WEB.PortalMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inicio-contenido">
        <div class="inicio-titulo">
            <h1>Portal Médico</h1>
        </div>
        <div class="inicio-botones">
            <a href="misPacientes.aspx" class="inicio-btn">Mis Pacientes</a>
            <a href="turnosDia.aspx" class="inicio-btn">Turnos del Día</a>
            <a href="registrarConsulta.aspx" class="inicio-btn">Registrar Consulta</a>
        </div>
    </div>
</asp:Content>
