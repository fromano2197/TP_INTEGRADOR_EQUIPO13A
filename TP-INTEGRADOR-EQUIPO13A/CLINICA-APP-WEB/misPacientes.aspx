<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="misPacientes.aspx.cs" Inherits="CLINICA_APP_WEB.misPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1 class="titulo-principal">Mis Pacientes</h1>

<div class="form-container">
    <div class="turno-item">
        <div class="form-group">
            <h2>Lucia Monges</h2>
            <p>DNI: 41804460</p>
            <p>Fecha ultima consulta: Sábado, 09 Nov. 2024</p>
            <p>Lugar: Clinica UTN, Larralde 123, CABA</p>
        </div>
        <asp:Button ID="btnVerHistoriaClinica" onclick="btnVerHistoriaClinica_Click" runat="server" Text="Historia Clinica" CssClass="btn-primary" />
    </div>

     <div class="turno-item">
      <div class="form-group">
          <h2>Pepe Marquez</h2>
          <p>DNI: 41456784</p>
          <p>Fecha ultima consulta: Sábado, 09 Nov. 2024</p>
          <p>Lugar: Clinica UTN, Larralde 123, CABA</p>
      </div>
      <asp:Button ID="btnVerHistoriaClinica2" OnClick="btnVerHistoriaClinica2_Click" runat="server" Text="Historia Clinica" CssClass="btn-primary" />
  </div>

       <div class="turno-item">
    <div class="form-group">
        <h2>Matias Martinez</h2>
        <p>DNI: 44556775</p>
        <p>Fecha ultima consulta: Viernes, 18 Oct. 2024</p>
        <p>Lugar: Clinica UTN, Larralde 123, CABA</p>
    </div>
    <asp:Button ID="btnVerHistoriaClinica3" OnClick="btnVerHistoriaClinica3_Click" runat="server" Text="Historia Clinica" CssClass="btn-primary" />
</div>
</div>
</asp:Content>
