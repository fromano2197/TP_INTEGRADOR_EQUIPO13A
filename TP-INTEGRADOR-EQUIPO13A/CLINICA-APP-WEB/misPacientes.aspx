<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="misPacientes.aspx.cs" Inherits="CLINICA_APP_WEB.misPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <ContentTemplate>
     <asp:GridView ID="dgvPacientes" runat="server" CssClass="table table-striped table-bordered"></asp:GridView>
     <link rel="stylesheet" type="text/css" href='<%= ResolveUrl("~/Content/estilos.css") %>' />
     <hr />
   <div class="contenedor">
         <h1 class="titulo-resultados">Mis Pacientes</h1>
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
                             <td><%# Eval("DatosPersona.Apellido") %></td>
                             <td><%# Eval("DatosPersona.Nombre") %></td>
                             <td><%# Eval("DatosPersona.Dni") %></td>
                             <td><asp:Button ID="btnDetalles" CommandName="Detalles" Oncommand="btnDetalles_Command" CommandArgument='<%# Eval("IdPaciente") %>' CssClass="btn-especialidad" runat="server" Text="Ver detalle de Paciente" />
                                 <asp:Button ID="btnHistoria" CommandName="HistoriaClinica" OnCommand="btnHistoria_Command" CommandArgument='<%# Eval("IdPaciente") %>' CssClass="btn-especialidad" runat="server" Text="Descargar Historia Clínica" /></td>
                         </tr>
                     </ItemTemplate>
                 </asp:Repeater>
             </tbody>
         </table>
     </div>
 </ContentTemplate>
</asp:Content>
