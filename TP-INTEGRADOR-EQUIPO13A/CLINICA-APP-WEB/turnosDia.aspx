<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="turnosDia.aspx.cs" Inherits="CLINICA_APP_WEB.turnosDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <h1 class="titulo-resultados">Mis Turnos</h1>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="contenedor-filtros">
                <asp:RadioButtonList 
                    ID="rbFiltrosTurnos" 
                    runat="server" 
                    RepeatDirection="Horizontal" 
                    AutoPostBack="true" 
                    OnSelectedIndexChanged="rbFiltrosTurnos_SelectedIndexChanged">
                    <asp:ListItem Text="Turnos del día" Value="dia" Selected="True" />
                    <asp:ListItem Text="Turnos de la semana" Value="semana" />
                    <asp:ListItem Text="Turnos del mes" Value="mes" />
                </asp:RadioButtonList>
            </div>
            <div class="table-responsive">
                <table class="table table-bordered table-hover">
                    <thead>
                        <tr>
                            <th>Especialidad</th>
                            <th>Apellido</th>
                            <th>Nombre</th>
                            <th>DNI</th>
                            <th>Fecha</th>
                            <th>Hora</th>
                            <th>Observaciones</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="repRepeater" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Especialidad.NombreEspecialidad") %></td>
                                    <td><%# Eval("Paciente.DatosPersona.Apellido") %></td>
                                    <td><%# Eval("Paciente.DatosPersona.Nombre") %></td>
                                    <td><%# Eval("Paciente.DatosPersona.Dni") %></td>
                                    <td><%# Eval("Fecha", "{0:dd/MM/yyyy}") %></td>
                                    <td><%# Eval("hora", "{0:hh\\:mm}") %></td>
                                    <td><%# Eval("Observaciones") %></td>
                                    <td>
                                        <asp:Button 
                                            ID="btnObservaciones" 
                                            CommandName="Observaciones" 
                                            OnCommand="btnObservaciones_Command" 
                                            CommandArgument='<%# Eval("IdTurno") %>' 
                                            CssClass="btn-especialidad visualizar" 
                                            runat="server" 
                                            Text="Agregar Observacion" />
                                        <asp:Button 
                                            ID="btnDetalles" 
                                            CommandName="Detalles" 
                                            OnCommand="btnDetalles_Command" 
                                            CommandArgument='<%# Eval("Paciente.IdPaciente") %>' 
                                            CssClass="btn-especialidad visualizar" 
                                            runat="server" 
                                            Text="Ver detalle de Paciente" />
                                        <asp:Button 
                                            ID="btnHistoria" 
                                            CommandName="HistoriaClinica" 
                                            OnCommand="btnHistoria_Command" 
                                            CommandArgument='<%# Eval("Paciente.IdPaciente") %>' 
                                            CssClass="btn-especialidad visualizar" 
                                            runat="server" 
                                            Text="Descargar Historia Clínica" />
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
