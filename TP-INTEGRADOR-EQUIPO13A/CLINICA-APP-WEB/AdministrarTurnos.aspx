<%@ Page Title="Administrar Turnos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarTurnos.aspx.cs" Inherits="CLINICA_APP_WEB.AdministrarTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
    <link rel="stylesheet" href="estilos.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <asp:UpdatePanel ID="UpdatePanelTurnos" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            <div class="contenedor-formulario1">
                <h2 class="titulo-formulario1">Agregar Turnos</h2>
                <div class="grupo-formulario oculto1">
                    <asp:Label ID="lblIdTurno" runat="server" Text="ID Turno (solo para modificar)" CssClass="etiqueta-formulario1"></asp:Label>
                    <asp:TextBox ID="txtIdTurno" runat="server" CssClass="entrada-formulario1" Visible="false"></asp:TextBox>
                </div>

                <div class="grupo-formulario1">
                    <asp:Label ID="lblProfesional" runat="server" Text="Profesional:" CssClass="etiqueta-formulario1"></asp:Label>
                    <asp:DropDownList ID="ddlProfesionales" runat="server" CssClass="seleccion-formulario1" AutoPostBack="true" OnSelectedIndexChanged="ddlProfesionales_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="grupo-formulario1">
                    <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad:" CssClass="etiqueta-formulario1"></asp:Label>
                    <asp:DropDownList ID="ddlEspecialidades" runat="server" CssClass="seleccion-formulario1"></asp:DropDownList>
                </div>

                <div class="grupo-formulario1">
                    <asp:Label ID="lblInstitucion" runat="server" Text="Institución:" CssClass="etiqueta-formulario1"></asp:Label>
                    <asp:DropDownList ID="ddlInstituciones" runat="server" CssClass="seleccion-formulario1"></asp:DropDownList>
                </div>

                <div class="grupo-formulario1">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha:" CssClass="etiqueta-formulario1"></asp:Label>
                    <asp:TextBox ID="txtFecha" runat="server" CssClass="entrada-formulario1" TextMode="Date"></asp:TextBox>
                </div>

                <div class="grupo-formulario1">
                    <asp:Label ID="lblHora" runat="server" Text="Hora:" CssClass="etiqueta-formulario1"></asp:Label>
                    <asp:DropDownList ID="ddlHora" runat="server" CssClass="seleccion-formulario1"></asp:DropDownList>
                </div>

                <div class="grupo-botones1">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Turno" CssClass="boton-formulario1" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="boton-formulario1" OnClick="btnLimpiar_Click" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
