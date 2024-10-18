<%@ Page Title="Turnos Pacientes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TurnosPacientes.aspx.cs" Inherits="CLINICA_APP_WEB.TurnosPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <form class="space-y-4">
            <div class="form-group">
                <label for="paciente" class="form-label">Paciente:</label>
                <select id="paciente" class="form-select">
                    <option>ROMANO FACUNDO EZEQUIEL</option>
                    <option>HERNAN MOLINA</option>
                    <option>LUCIA MONGES</option>
                    <option>MAXI PROGRAMA</option>
                </select>
            </div>


            <div class="form-group">
    <label for="Cobertura" class="form-label">Cobertura:</label>
    <select id="Cobertura" class="form-select">
        <option>SELECCIONAR</option>
        <option>OSDE</option>
        <option>CAMIONEROS</option>
        <option>PARTICULAR</option>
    </select>
</div>

            <div class="form-group">
                <label for="especialidad" class="form-label">Especialidad:</label>
                <select id="especialidad" class="form-select">
                    <option>SELECCIONAR</option>
                    <option>CLINICA MEDICA</option>
                    <option>CARDIOLOGÍA</option>
                    <option>TRAUMATOLOGÍA</option>
                    <option>GINECOLOGÍA</option>
                </select>
            </div>

            <div class="form-group">
                <label for="medico" class="form-label">Médico:</label>
                <select id="medico" class="form-select">
                    <option>TODOS</option>
                    <option>DOCTOR AMOR</option>
                    <option>DOCTOR DOLITTLE</option>
                    <option>GASTON PORTAL</option>
                    <option>DOCTOR ACHURA</option>
                </select>
            </div>

            <button type="submit" class="btn-primary">
                Consultar turnos disponibles
            </button>
        </form>
    </div>
</asp:Content>
