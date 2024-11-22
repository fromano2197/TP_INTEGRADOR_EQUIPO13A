<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EstudiosDePacientes.aspx.cs" Inherits="CLINICA_APP_WEB.EstudiosDePacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
            <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
            <hr />
            <div class="contenedor">
                <h1 class="titulo-resultados">Lista de Pacientes</h1>
                <label for="txtBuscarPaciente" class="etiqueta-formulario">Buscar Paciente:</label>
                <asp:TextBox ID="txtBuscarPaciente" CssClass="entrada-formulario" runat="server" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeholder="Buscar por Apellido,Nombre o Dni" />
            </div>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Apellido</th>
                            <th>Nombre</th>
                            <th>DNI</th>
                            <th>Estado</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("DatosPersona.Apellido") %></td>
                                    <td><%# Eval("DatosPersona.Nombre") %></td>
                                    <td><%# Eval("DatosPersona.Dni") %></td>
                                    <td><%# Eval("activo").ToString() == "False" ? "Eliminado" : "Activo" %></td>
                                    <td>
                                        <asp:Button ID="btnCargarEstudios" CommandName="CargarEstudios" CommandArgument='<%# Eval("idPaciente") %>' OnCommand="btnCargarEstudios_Command" CssClass="btn-especialidad" runat="server" Text="Cargar Estudios" />
                                        

                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
