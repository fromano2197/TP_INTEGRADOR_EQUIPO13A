<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisTurnos.aspx.cs" Inherits="CLINICA_APP_WEB.MisTurnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="titulo-principal">Mis Turnos</h1>

    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>


    <asp:GridView 
        ID="gvTurnos" 
        runat="server" 
        AutoGenerateColumns="False" 
        DataKeyNames="id_turno" 
        OnRowCommand="gvTurnos_RowCommand" 
        CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="Medico" HeaderText="Médico" />
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
            <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="hora" HeaderText="Hora" />
            <asp:BoundField DataField="Institucion" HeaderText="Institución" />
            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
            

            <asp:ButtonField 
                ButtonType="Button" 
                Text="Cancelar" 
                CommandName="CancelarTurno" 
                HeaderText="Acciones" 
                ControlStyle-CssClass="btn-especialidad eliminar" />
        </Columns>
    </asp:GridView>
</asp:Content>
