<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BuscarProfesional.aspx.cs" Inherits="CLINICA_APP_WEB.BuscarProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
    <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />

        <h1 class="titulo-resultados">Lista de Profesionales</h1>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <label for="txtBuscarProfesional" class="etiqueta-formulario">Buscar Profesional:</label>
        <asp:TextBox ID="txtBuscarProfesional" CssClass="entrada-formulario" runat="server" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeholder="Buscar por Apellido, Nombre, Especialidad o Institución" />
  
    <div class="contenedor-boton">
        <asp:Button ID="btnAgregarProfesional" runat="server" Text="AGREGAR PROFESIONAL +" CssClass="btn-agregar-profesional" OnClick="btnAgregarProfesional_Click"  />
    </div>
    <div class="table-responsive">
        <table class="table table-bordered table-hover">
            <thead>
                <tr>
                    <th>Apellido</th>
                    <th>Nombre</th>
                    <th>Especialidad</th>
                    <th>Institución</th>
                    <th>Estado</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="repRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td style="display: none;"><%# Eval("Persona.IdPersona") %></td>
                            <td><%# Eval("Persona.Apellido") %></td>
                            <td><%# Eval("Persona.Nombre") %></td>
                            <td><%# String.Join(", ", ((List<Dominio.Especialidad>)Eval("Especialidades")).Select(especialidad => especialidad.NombreEspecialidad)) %></td>
                            <td><%# String.Join(", ", ((List<Dominio.Institucion>)Eval("Institucion")).Select(institucion => institucion.Nombre)) %></td>
                            <td><%# Eval("Estado").ToString() == "False" ? "Eliminado" : "Activo" %></td>
                            <td>
                                <asp:Button ID="btnVisualizar" CommandName="Visualizar"
                                    CommandArgument='<%# Eval("Persona.IdPersona") %>'
                                    OnCommand="btnVisualizar_Command"
                                    CssClass="btn-especialidad" runat="server" Text="Visualizar" />

                                    <asp:Button ID="btnModificar" CommandName="Modificar"
                                    CommandArgument='<%# Eval("Persona.IdPersona") %>'
                                    OnCommand="btnModificar_Command"
                                    CssClass="btn-especialidad" runat="server" Text="Modificar" />
                             
                                    <asp:Button ID="btnEliminar" CommandName="Eliminar"
                                    CommandArgument='<%# Eval("IdProfesional") %>' 
                                    OnCommand="btnEliminar_Command"
                                    CssClass="btn-especialidad" runat="server" 
                                    Text='<%# Eval("Estado").ToString() == "True" ? "Eliminar" : "Activar" %>' />

                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
                </ContentTemplate>
             <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtBuscarProfesional" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
      
</asp:Content>
