<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BuscarPaciente.aspx.cs" Inherits="CLINICA_APP_WEB.BuscarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
            <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
            <hr />
            <div class="contenedor">
                <h1 class="titulo-resultados">Lista de Pacientes</h1>
                <label for="txtBuscarPaciente" class="etiqueta-formulario">Buscar Paciente:</label>
                <asp:TextBox ID="txtBuscarPaciente" CssClass="entrada-formulario" runat="server" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeholder="Buscar por Apellido,Nombre o Dni" />
            </div>
            <div class="contenedor-boton">
                <asp:Button ID="btnAgregarProfesional" runat="server" Text="AGREGAR PACIENTE +" CssClass="btn-agregar-profesional" OnClick="btnAgregarProfesional_Click" />
            </div>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Apellido</th>
                            <th>Nombre</th>
                            <th>DNI</th>
                            <th>Estado</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("DatosPersona.Apellido") %></td>
                                    <td><%# Eval("DatosPersona.Nombre") %></td>
                                    <td><%# Eval("DatosPersona.Dni") %></td>
                                    <td><%# Eval("activo").ToString() == "False" ? "Eliminado" : "Activo" %></td>
                                    <td>
                                        <asp:Button ID="btnVisualizar" CommandName="Visualizar" CommandArgument='<%# Eval("IdPaciente") %>' OnCommand="btnVisualizar_Command" CssClass="btn-especialidad" runat="server" Text="Visualizar" />
                                        <asp:Button ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("IdPaciente") %>' OnCommand="btnModificar_Command" CssClass="btn-especialidad" runat="server" Text="Modificar" />
                                        <asp:Button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdPaciente") %>' OnCommand="btnEliminar_Command1" CssClass="btn-especialidad" runat="server" Text='<%# Eval("activo").ToString() == "True" ? "Eliminar" : "Activar" %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
