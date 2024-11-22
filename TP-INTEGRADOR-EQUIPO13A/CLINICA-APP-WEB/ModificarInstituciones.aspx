<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarInstituciones.aspx.cs" Inherits="CLINICA_APP_WEB.ModificarInstituciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
        
        <div class="contenedor">
            <h1 class="titulo-resultados">Lista de Instituciones del Profesional</h1>
         
        </div>
                <div class="contenedor-boton">
    <asp:Button ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn-agregar-profesional" runat="server" Text="Agregar Institucion +" />
    </div>
        <div class="table-responsive">
            <table class="table table-bordered table-hover">
                <thead>
                    <tr>
          
                        <th>Nombre Institucion</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="repRepeaterInstitucion" runat="server">
                        <ItemTemplate>
                            <tr>
                          
                                <td><%# Eval("Nombre") %></td>
                                <td>
                                    <asp:Button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdInstitucion") %>' OnCommand="btnEliminar_Command" CssClass="btn-especialidad" runat="server" Text="Eliminar" />
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
