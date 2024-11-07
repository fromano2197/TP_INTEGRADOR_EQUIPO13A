<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BuscarPaciente.aspx.cs" Inherits="CLINICA_APP_WEB.BuscarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
    <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
    <hr />
    <div class="contenedor">
        <h1 class="titulo-resultados">Lista de Pacientes</h1>
        <label for="txtDni" class="etiqueta-formulario">Buscar Paciente:</label>
        <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Introducir Apellido,Nombre o Dni" />
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
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                           
                            <td><%# Eval("Apellido") %></td>
                            <td><%# Eval("Nombre") %></td>
                            <td><%# Eval("Dni") %></td>

                            
                             <td>
                            <asp:Button ID="btnVisualizar" CommandName="Visualizar" CommandArgument='<%# Eval("IdPersona") %>' OnCommand="btnVisualizar_Command" autopostback="true" CssClass="btn-especialidad" runat="server" Text="Visualizar" />
                            <asp:button ID="btnModificar" CommandName="Modificar" CommandArgument='<%# Eval("IdPersona") %>' Oncommand="btnModificar_Command" CssClass="btn-especialidad" runat="server" Text="Modificar"/>
                            <asp:button ID="btnEliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdPersona") %>' Oncommand="btnEliminar_Command1" CssClass="btn-especialidad" runat="server" Text="Eliminar"/>
                             </td>      
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
