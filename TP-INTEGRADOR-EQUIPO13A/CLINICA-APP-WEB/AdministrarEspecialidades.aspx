<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarEspecialidades.aspx.cs" Inherits="CLINICA_APP_WEB.AdministrarEspecialidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
            <div class="contenedor">
                <h1 class="titulo-resultados">Lista de Especialidades</h1>

                <label for="txtBuscarEspecialidad" class="etiqueta-formulario">Buscar Especialidad:</label>
                <asp:TextBox ID="txtBuscarEspecialidad" CssClass="entrada-formulario" runat="server" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeholder="Buscar por Especialidad" />
            </div>
            <div class="contenedor-boton">
    <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn-agregar-profesional" runat="server" Text="Agregar Especialidad +" />
            </div>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Especialidad</th>
                            <th>Estado</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repRepeaterEspecialidad" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("IdEspecialidad") %></td>
                                    <td><%# Eval("NombreEspecialidad") %></td>
                                    <td><%# Eval("activo").ToString() == "False" ? "Eliminado" : "Activo" %></td>
                                    <td>
                                        <asp:Button ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("IdEspecialidad") %>' OnCommand="btnModificar_Command" CssClass="btn-especialidad" runat="server" Text="Modificar" />
                                        <asp:Button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdEspecialidad") %>' OnCommand="btnEliminar_Command" CssClass="btn-especialidad" runat="server" Text='<%# Eval("activo").ToString() == "True" ? "Eliminar" : "Activar" %>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>

            <hr />
            
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
