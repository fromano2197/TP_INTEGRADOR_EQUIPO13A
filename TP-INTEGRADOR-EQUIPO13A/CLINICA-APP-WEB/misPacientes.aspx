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
         <%--<label for="txtBuscarPaciente" class="etiqueta-formulario">Buscar Paciente:</label>--%>
        <%-- <asp:TextBox ID="txtBuscarPaciente" CssClass="entrada-formulario" runat="server" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeholder="Buscar por Apellido,Nombre o Dni" />--%>
     </div>
     
     <div class="table-responsive">
         <table class="table table-bordered table-hover">
             <thead>
                 <tr>
                     <th>Apellido</th>
                     <th>Nombre</th>
                     <th>DNI</th>
                 </tr>
             </thead>
             <tbody>
                 <asp:Repeater ID="repRepeater" runat="server">
                     <ItemTemplate>
                         <tr>
                             <td><%# Eval("Apellido") %></td>
                             <td><%# Eval("Nombre") %></td>
                             <td><%# Eval("Dni") %></td>
                         </tr>
                     </ItemTemplate>
                 </asp:Repeater>
             </tbody>
         </table>
     </div>
 </ContentTemplate>
</asp:Content>
