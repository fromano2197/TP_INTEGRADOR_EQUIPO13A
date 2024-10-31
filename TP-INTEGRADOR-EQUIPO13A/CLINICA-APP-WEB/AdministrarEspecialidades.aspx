<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarEspecialidades.aspx.cs" Inherits="CLINICA_APP_WEB.AdministrarEspecialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
    <div class="contenedor">
    <h1 class="titulo-resultados">Lista de Especialidades</h1>

    <label for="txtDni" class="etiqueta-formulario">Buscar Especialidad:</label>
    <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Introducir Especialidad"/>
</div>
    <div>
        <div class="table-responsive">
    <table class="table table-bordered table-hover">
        <thead>
            <tr>
                <th>ID</th>
                 <th>Especialidad</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="repRepeaterEspecialidad" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("IdEspecialidad") %></td>
                        <td><%# Eval("NombreEspecialidad") %></td>
                        <td>
                     <asp:button ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("IdEspecialidad") %>' OnCommand="btnModificar_Command" CssClass="btn-especialidad" runat="server" Text="Modificar"/>
                     <asp:button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdEspecialidad") %>' OnCommand="btnEliminar_Command" CssClass="btn-especialidad" runat="server" Text="Eliminar"/>
                        </td>      
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>
        <hr>
        </div>

        <div>
            <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass ="btn-especialidad" runat="server" Text="Agregar Especialidad" />
        </div>

</asp:Content>

