<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BuscarProfesional.aspx.cs" Inherits="CLINICA_APP_WEB.BuscarProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
    <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
    <div class="contenedor">
        <h1 class="titulo-resultados">Lista de Profesionales</h1>

        <label for="txtBuscarProfesional" class="etiqueta-formulario">Buscar Profesional:</label>
        <asp:TextBox ID="txtBuscarProfesional" CssClass="entrada-formulario" runat="server" placeholder="Buscar por Apellido, Nombre, Especialidad o Institución" />
    </div>
    <div class="contenedor-boton">
        <asp:Button ID="btnAgregarProfesional" runat="server" Text="AGREGAR PROFESIONAL +" CssClass="btn-agregar-profesional" OnClick="btnAgregarProfesional_Click"  />
    </div>
    <div class="table-responsive">
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>Apellido</th>
                    <th>Nombre</th>
                    <th>Especialidad</th>
                    <th>Institución</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="display: none;"><%# Eval("Persona.IdPersona") %></td>
                            <td><%# Eval("Persona.Apellido") %></td>
                            <td><%# Eval("Persona.Nombre") %></td>
                            <td><%# String.Join(", ", ((List<Dominio.Especialidad>)Eval("Especialidades")).Select(especialidad => especialidad.NombreEspecialidad)) %></td>
                            <td><%# Eval("Institucion.Nombre") %></td>
                            <td>
                                <asp:Button ID="btnVisualizar" CommandName="Visualizar"
                                    CommandArgument='<%# Eval("Persona.IdPersona") %>'
                                    OnCommand="btnVisualizar_Command"
                                    CssClass="btn-especialidad" runat="server" Text="Visualizar" />
                                <asp:Button ID="btnEliminar" CommandName="Eliminar"
                                    CommandArgument='<%# Eval("Persona.IdPersona") %>'
                                    OnCommand="btnEliminar_Command"
                                    CssClass="btn-especialidad" runat="server" Text="Eliminar" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
