<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarInstituciones.aspx.cs" Inherits="CLINICA_APP_WEB.AdministrarInstituciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
            
            <div class="contenedor">
                <h1 class="titulo-resultados">Lista de Instituciones</h1>
                <label for="txtBuscarInstitucion" class="etiqueta-formulario">Buscar Institucion:</label>
                <asp:TextBox ID="txtBuscarInstitucion" CssClass="entrada-formulario" runat="server" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeholder="Introducir Institución" />
            </div>
                    <div class="contenedor-boton">
        <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn-agregar-profesional" runat="server" Text="Agregar Institucion +" />
        </div>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Nombre Institucion</th>
                            <th>Direccion</th>
                            <th>Fecha Apertura</th>
                            <th>Estado</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repRepeaterInstitucion" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("IdInstitucion") %></td>
                                    <td><%# Eval("Nombre") %></td>
                                    <td><%# Eval("Direccion") %></td>
                                    <td><%# Eval("Fecha_Apertura", "{0:dd/MM/yyyy}") %></td>
                                    <td><%# Eval("activo").ToString() == "False" ? "Eliminado" : "Activo" %></td>
                                    <td>
                                        <asp:Button ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("IdInstitucion") %>' OnCommand="btnModificar_Command" CssClass="btn-especialidad modificar" runat="server" Text="Modificar" />
                                        <asp:Button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdInstitucion") %>' OnCommand="btnEliminar_Command" CssClass="btn-especialidad eliminar" runat="server" Text='<%# Eval("activo").ToString() == "True" ? "Eliminar" : "Activar" %>' />
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
