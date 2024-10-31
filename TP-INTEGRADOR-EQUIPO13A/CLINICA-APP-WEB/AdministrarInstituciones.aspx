<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdministrarInstituciones.aspx.cs" Inherits="CLINICA_APP_WEB.AdministrarInstituciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
    <div class="contenedor">
    <h1 class="titulo-resultados">Lista de Instituciones</h1>
    <label for="txtDni" class="etiqueta-formulario">Buscar Institucion:</label>
    <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Introducir Institución" />
</div>
    <div>
        <div class="table-responsive">
    <table class="table table-bordered table-hover">
        <thead>
            <tr>
                <th>ID</th>
                 <th>Nombre Institucion</th>
                 <th>Direccion</th>
                <th>Fecha Apertura</th>
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
                        <td><%# Eval("Fecha_Apertura") %></td>     
                        
                        
                           <td>
                    <asp:button ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("IdInstitucion") %>' OnCommand="btnModificar_Command" CssClass="btn-especialidad" runat="server" Text="Modificar"/>
                    <asp:button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdInstitucion") %>' OnCommand="btnEliminar_Command" CssClass="btn-especialidad" runat="server" Text="Eliminar"/>
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
    <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass ="btn-especialidad" runat="server" Text="Agregar Institucion" />
</div>


</asp:Content>
