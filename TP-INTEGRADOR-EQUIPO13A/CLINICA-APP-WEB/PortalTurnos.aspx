<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PortalTurnos.aspx.cs" Inherits="CLINICA_APP_WEB.PortalTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="inicio-contenido">
     <div class="inicio-titulo">
         <h1>Portal Turnos</h1>
     </div>
     <div class="inicio-botones">
         <a href="AdministrarTurnos.aspx" class="inicio-btn">Crear Turno</a>
         <a href="VerTurnos.aspx" class="inicio-btn">Ver Turnos</a>

     </div>
 </div>
</asp:Content>
