<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="CLINICA_APP_WEB.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="inicio-contenido">
     <div class="inicio-titulo">
         <h1>Portal ADMIN</h1>
     </div>
     <div class="inicio-botones">
         <a href="BuscarPaciente.aspx" class="inicio-btn">Pacientes</a>
         <a href="BuscarProfesional.aspx" class="inicio-btn">Profesionales</a>
         <a href="AdministrarEspecialidades.aspx" class="inicio-btn">Especialidades</a>
         <a href="AdministrarInstituciones.aspx" class="inicio-btn">Instituciones</a>
         <a href="EstudiosDePacientes.aspx" class="inicio-btn">Cargar Estudios</a>
     </div>
 </div>
</asp:Content>
