<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PortalPacientes.aspx.cs" Inherits="CLINICA_APP_WEB.PortalPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<nav class="navbar navbar-expand-lg bg-body-tertiary">
  <div class="container-fluid">
    <a class="navbar-brand" href="default.aspx">Inicio Clinica UTN</a>
   
    <div class="collapse navbar-collapse" id="navbarnav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link active" aria-current="page" href="#">Pedir Turno</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Mis Turnos</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">Mis Estudios</a>
        </li>
          <li class="nav-item">
        <a class="nav-link" href="#">Mis Datos Personales</a>
          </li>
      </ul>
    </div>
  </div>
</nav>

<div class="inicio-contenido">
    <div class="inicio-titulo">
    </div>
    <div class="inicio-botones">
        <a href="#" class="inicio-btn">Pedir Turno</a>
        <a href="#" class="inicio-btn">Mis Turnos</a>
        <a href="#" class="inicio-btn">Mis Estudios</a>
        <a href="#" class="inicio-btn">Mis Datos Personales</a>
    
    </div>
</div>
</asp:Content>
