<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerTurnos.aspx.cs" Inherits="CLINICA_APP_WEB.VerTurnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <h1 class="titulo-resultados">Turnos</h1>
    </div>
    <asp:Label ID="lblError" runat="server" Text="Turno eliminado ✅" Visible="false" CssClass="mensaje-error" />
    <asp:Timer ID="timerMensaje" runat="server" OnTick="timerMensaje_Tick" Interval="3000" Enabled="false" />

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Visible="false"></asp:Label>

    <label for="txtBuscarTurno" class="etiqueta-formulario">Buscar Turno:</label>
    <asp:TextBox ID="txtBuscarTurno" CssClass="entrada-formulario" runat="server" AutoPostBack="true"
        OnTextChanged="filtro_TextChanged" placeholder="Buscar por Nombre, Apellido, DNI o Fecha" />


    <asp:GridView ID="gvTurnos" runat="server" CssClass="table table-striped" AutoGenerateColumns="False"
        OnRowCommand="gvTurnos_RowCommand" OnRowDataBound="gvTurnos_RowDataBound" DataKeyNames="id_turno">
        <Columns>
            <asp:BoundField DataField="apellido_paciente" HeaderText="Apellido Paciente" SortExpression="apellido_paciente" />
            <asp:BoundField DataField="nombre_paciente" HeaderText="Nombre Paciente" SortExpression="nombre_paciente" />
            <asp:BoundField DataField="apellido" HeaderText="Apellido Profesional" SortExpression="apellido" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre Profesional" SortExpression="nombre" />
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" SortExpression="Especialidad" />
            <asp:BoundField DataField="Institucion" HeaderText="Institución" SortExpression="Institucion" />
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha" />
            <asp:BoundField DataField="Hora" HeaderText="Hora" SortExpression="Hora" />
            <asp:BoundField DataField="Observacion" HeaderText="Observaciones" SortExpression="Observacion" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Button ID="btnAsignar" runat="server" Text="Asignar Turno"
                        CommandName="AsignarTurno" CommandArgument='<%# Container.DataItemIndex %>' CssClass="button-base btnAsignar" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar Turno"
                        CommandName="CancelarTurno" CommandArgument='<%# Container.DataItemIndex %>' CssClass="button-base btnEliminar" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
