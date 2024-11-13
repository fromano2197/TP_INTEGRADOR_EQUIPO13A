<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PortalPacientes.aspx.cs" Inherits="CLINICA_APP_WEB.PortalPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="inicio-contenido">
        <div class="inicio-titulo">
        </div>
        <div class="inicio-botones">
            <a href="TurnosPacientes.aspx" class="inicio-btn">Nuevo Turno</a>
            <a href="MisTurnos.aspx" class="inicio-btn">Mis Turnos</a>
            <a href="MisEstudios.aspx" class="inicio-btn">Mis Estudios</a>

            <asp:LinkButton ID="btnMisDatosPersonales" runat="server" CssClass="inicio-btn" CommandName="Visualizar" CommandArgument='<%#Eval ("id")%>' OnCommand="btnVisualizar_Command"> Mis Datos Personales</asp:LinkButton>
        </div>
    </div>
</asp:Content>
