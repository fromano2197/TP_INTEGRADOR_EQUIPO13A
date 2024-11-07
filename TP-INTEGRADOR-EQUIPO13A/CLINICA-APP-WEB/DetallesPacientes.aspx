<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallesPacientes.aspx.cs" Inherits="CLINICA_APP_WEB.DetallesPacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="contenedor">
     
        <h1 class="titulo-principal">DETALLES DEL PACIENTE</h1>
        <div>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Visible="False"></asp:Label>
        </div>
        
        <div class="contenedor-formulario">
            <div class="grupo-formulario">
                <label for="txtDni" class="etiqueta-formulario">Número de documento:</label>
                <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Número de documento" ReadOnly="true" />
            </div>

            <div class="grupo-formulario">
                <label for="txtNombre" class="etiqueta-formulario">Nombre:</label>
                <asp:TextBox ID="txtNombre" CssClass="entrada-formulario" runat="server" placeholder="Nombre completo" ReadOnly="true" />
            </div>

            <div class="grupo-formulario">
                <label for="txtApellido" class="etiqueta-formulario">Apellido:</label>
                <asp:TextBox ID="txtApellido" CssClass="entrada-formulario" runat="server" placeholder="Apellido completo" ReadOnly="true" />
            </div>
            
            <div class="grupo-formulario">
                <label for="txtFechaNac" class="etiqueta-formulario">Fecha de nacimiento:</label>
                <asp:TextBox ID="txtFechaNac" CssClass="entrada-formulario" runat="server" placeholder="Fecha de nacimiento" ReadOnly="true" />
            </div>
            
            <div class="grupo-formulario">
                <label for="txtEmail" class="etiqueta-formulario">Correo Electrónico:</label>
                <asp:TextBox ID="txtEmail" CssClass="entrada-formulario" runat="server" placeholder="Correo electrónico" ReadOnly="true" />
            </div>
            
            <div class="grupo-formulario">
                <label for="txtTelefono" class="etiqueta-formulario">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" CssClass="entrada-formulario" runat="server" placeholder="Teléfono" ReadOnly="true" />
            </div>          

            <div class="grupo-formulario">
                <label for="txtDireccion" class="etiqueta-formulario">Dirección:</label>
                <asp:TextBox ID="txtDireccion" CssClass="entrada-formulario" runat="server" placeholder="Dirección" ReadOnly="true" />
        </div>
    </div>
             </div>
</asp:Content>
