<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="CLINICA_APP_WEB.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="inicio-contenido">
     <div class="inicio-titulo">
         <h1>Portal ADMIN</h1>
     </div>
     <div class="inicio-botones">
         <a href="BuscarPaciente.aspx" class="inicio-btn">Administrar Pacientes</a>
         <a href="BuscarProfesional.aspx" class="inicio-btn">Administrar Profesionales</a>
         <a href="BuscarInstituciones.aspx" class="inicio-btn">Administrar Instituciones</a>
     </div>
 </div>
</asp:Content>
