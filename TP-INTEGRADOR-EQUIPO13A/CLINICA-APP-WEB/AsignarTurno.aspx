<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="CLINICA_APP_WEB.AsignarTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <h1 class="titulo-resultados">Lista de Pacientes</h1>

        <label for="txtBuscarPaciente" class="etiqueta-formulario">Buscar Paciente:</label>
        <asp:TextBox ID="txtBuscarPaciente" CssClass="entrada-formulario" runat="server" AutoPostBack="true" 
            OnTextChanged="filtro_TextChanged" placeholder="Buscar por Apellido, Nombre o DNI" />
    </div>

    <div class="contenedor">
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-success" Visible="false"></asp:Label>
        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
        
        <asp:GridView ID="gvPacientes" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" 
            DataKeyNames="id_paciente" OnRowCommand="gvPacientes_RowCommand">
            <Columns>
                <asp:BoundField DataField="id_paciente" HeaderText="ID Paciente" SortExpression="id_paciente" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
                <asp:BoundField DataField="dni" HeaderText="DNI" SortExpression="dni" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnSeleccionar" runat="server" Text="Asignar a este Paciente" 
                            CommandName="AsignarPaciente" CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
