<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PortalMedicos.aspx.cs" Inherits="CLINICA_APP_WEB.PortalMedicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inicio-contenido">
        <div class="inicio-titulo">
            <h1>Portal Médico</h1>
        </div>
        <div class="inicio-botones">
            <asp:Button ID="btnMisPacientes" CommandName="Pacientes" Oncommand="btnMisPacientes_Command" CssClass="inicio-btn" runat="server" Text="Mis Pacientes" />
            <asp:Button ID="btnTurnos" CommandName="Turnos"  Oncommand="btnTurnos_Command" CssClass="inicio-btn" runat="server" Text="Mis Turnos" />
            <asp:Button ID="btnRegistrarConsulta" CommandName="Consulta" Oncommand="btnRegistrarConsulta_Command" CssClass="inicio-btn" runat="server" Text="Registrar Consulta" />
           
        </div>
    </div>
</asp:Content>
