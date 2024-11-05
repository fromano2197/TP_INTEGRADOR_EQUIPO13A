<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BuscarProfesional.aspx.cs" Inherits="CLINICA_APP_WEB.BuscarProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
    <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
    <hr />
    <div class="contenedor">
        <h1 class="titulo-resultados">Lista de Profesionales</h1>
        <label for="txtDni" class="etiqueta-formulario">Buscar Profesional:</label>
        <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Introducir Apellido,Nombre o Dni" required="required" />
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
                            <td><%# Eval("Persona.Apellido") %></td>
                            <td><%# Eval("Persona.Nombre") %></td>
                            <td><%# Eval("Especialidades") %></td>
                            <td><%# Eval("Institucion.Nombre") %></td>
                            <td>              
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary btn-sm" 
                                            CommandName="Modificar" CommandArgument='<%# Eval("Persona.IdPersona") %>' />

                                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" 
                                            CommandName="Eliminar" CommandArgument='<%# Eval("Persona.IdPersona") %>' 
                                            OnClientClick="return confirm('¿Está seguro de que desea eliminar este profesional?');" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>

</asp:Content>
