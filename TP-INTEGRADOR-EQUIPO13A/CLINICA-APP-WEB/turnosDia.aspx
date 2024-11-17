<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="turnosDia.aspx.cs" Inherits="CLINICA_APP_WEB.turnosDia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="contenedor">
               <h1 class="titulo-resultados">Mis Turnos</h1>
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
                                   <td><%# Eval("Fecha") %></td>
                                   <td><%# Eval("Observaciones") %></td>
                                   <td>
                                       <asp:Button ID="btnObservaciones" CommandName="Observaciones" OnCommand="btnObservaciones_Command" CommandArgument='<%# Eval("IdTurno") %>' CssClass="btn-especialidad" runat="server" Text="Agregar Observacion"/>
                                       <asp:Button ID="btnDetalles" CommandName="Detalles" OnCommand="btnDetalles_Command" CommandArgument='<%# Eval("Paciente.IdPaciente") %>' CssClass="btn-especialidad" runat="server" Text="Ver detalle de Paciente" /></td>
                               </tr>
                           </ItemTemplate>
                       </asp:Repeater>
                   </tbody>
               </table>
           </div>

</asp:Content>
