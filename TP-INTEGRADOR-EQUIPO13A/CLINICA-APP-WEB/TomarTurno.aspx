<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TomarTurno.aspx.cs" Inherits="CLINICA_APP_WEB.TomarTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titulo-principal">Turnos Disponibles</h1>

    <div class="form-container">
        <div class="turno-item">
            <div class="form-group">
                <h2>Dr. Kienkarajo Tekura</h2>
                <p>Especialidad: Traumatología</p>
                <p>Fecha: Sábado, 09 Nov. 2024</p>
                <p>Hora: 08:40</p>
                <p>Lugar: Clinica UTN, Larralde 123, CABA</p>
            </div>
            <asp:Button ID="btnTomarTurno1" runat="server" Text="Tomar turno" CssClass="btn-primary" />
        </div>

        <div class="turno-item">
            <div class="form-group">
                <h2>Alberto Comino Grande</h2>
                <p>Especialidad: Dermatología</p>
                <p>Fecha: Viernes, 15 Nov. 2024</p>
                <p>Hora: 09:40</p>
                <p>Lugar: Clinica UTN, Larralde 123, CABA</p>
            </div>
            <asp:Button ID="btnTomarTurno2" runat="server" Text="Tomar turno" CssClass="btn-primary" />
        </div>

        <div class="turno-item">
            <div class="form-group">
                <h2>María Teresa Panzzita</h2>
                <p>Especialidad: Nutrición</p>
                <p>Fecha: Viernes, 15 Nov. 2024</p>
                <p>Hora: 10:00</p>
                <p>Lugar: Clinica UTN, Larralde 123, CABA</p>
            </div>
            <asp:Button ID="btnTomarTurno3" runat="server" Text="Tomar turno" CssClass="btn-primary" />
        </div>
    </div>
</asp:Content>
