<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarEspecialidades.aspx.cs" Inherits="CLINICA_APP_WEB.ModificarEspecialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
        <div class="contenedor">
            <h1 class="titulo-resultados">Especialidades del Profesional</h1>
        </div>
        <div class="contenedor-boton">
<asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn-agregar-profesional" runat="server" Text="Agregar Especialidad al Profesional +" />
        </div>
        <div class="table-responsive">
            <table class="table table-bordered table-hover">
                <thead>
                    <tr>
                        <th>Especialidad</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repRepeaterEspecialidad" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("NombreEspecialidad") %></td>
                                <td>
                                    <asp:Button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdEspecialidad") %>' OnCommand="btnEliminar_Command" CssClass="btn-especialidad" runat="server" Text="Eliminar" />
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
