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
        <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Introducir Apellido,Nombre o Dni" required="required" />
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
                                <a class="btnAcciones" href="DetallePaciente.aspx?id=<%# Eval("IDPERSONA") %>">Ver Detalle</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</asp:Content>
