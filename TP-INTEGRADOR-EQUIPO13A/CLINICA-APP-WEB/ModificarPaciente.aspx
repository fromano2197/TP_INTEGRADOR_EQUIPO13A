<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarPaciente.aspx.cs" Inherits="CLINICA_APP_WEB.ModificarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">

        <h1 class="titulo-principal">
           <% 
                
                if (Session["TipoUsuario"] != null && Session["TipoUsuario"].ToString() == "paciente") 
                { 
                  
                    Response.Write("Perfil"); 
                } 
                else 
                { 

                    Response.Write("Detalles del Paciente"); 
                } 
            %>
        </h1>
        <div>
            <asp:Label ID="lblMensaje" runat="server" ForeColor="Green" Visible="False"></asp:Label>
        </div>

        <div class="contenedor-formulario">
            <div class="grupo-formulario">
                <label for="txtDni" class="etiqueta-formulario">Número de documento:</label>
                <asp:TextBox ID="txtDni" CssClass="entrada-formulario" runat="server" placeholder="Número de documento" />
            </div>

            <div class="grupo-formulario">
                <label for="txtNombre" class="etiqueta-formulario">Nombre:</label>
                <asp:TextBox ID="txtNombre" CssClass="entrada-formulario" runat="server" placeholder="Nombre completo" />
            </div>

            <div class="grupo-formulario">
                <label for="txtApellido" class="etiqueta-formulario">Apellido:</label>
                <asp:TextBox ID="txtApellido" CssClass="entrada-formulario" runat="server" placeholder="Apellido completo" />
            </div>

            <div class="grupo-formulario">
                <label for="txtFechaNac" class="etiqueta-formulario">Fecha de nacimiento:</label>
                <asp:TextBox ID="txtFechaNac" CssClass="entrada-formulario" runat="server" placeholder="Fecha de nacimiento" />
            </div>

            <div class="grupo-formulario">
                <label for="txtEmail" class="etiqueta-formulario">Correo Electrónico:</label>
                <asp:TextBox ID="txtEmail" CssClass="entrada-formulario" runat="server" placeholder="Correo electrónico" />
            </div>

            <div class="grupo-formulario">
                <label for="txtTelefono" class="etiqueta-formulario">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" CssClass="entrada-formulario" runat="server" placeholder="Teléfono" />
            </div>

            <div class="grupo-formulario">
                <label for="txtDireccion" class="etiqueta-formulario">Dirección:</label>
                <asp:TextBox ID="txtDireccion" CssClass="entrada-formulario" runat="server" placeholder="Dirección" />
            </div>
            <div class="grupo-formulario">
                <label for="txtUser" class="etiqueta-formulario">Usuario:</label>
                <asp:TextBox ID="TxtUser" CssClass="entrada-formulario" runat="server" placeholder="Usuario" />
            </div>
            <div class="grupo-formulario">
                <label for="txtPass" class="etiqueta-formulario">Contraseña:</label>
                <asp:TextBox ID="txtPass" CssClass="entrada-formulario" runat="server" placeholder="Contraseña" />
            </div>
            <div id="divPaciente" runat="server" visible="false">
                <asp:Button ID="btnModificarPaciente" OnClick="btnModificarPaciente_Click1" Text="Modificar Paciente" CssClass="btn-enviar" runat="server" />
            </div>

            <div id="divAdministrador" runat="server" visible="false">
                <asp:Button ID="Button1" OnClick="btnModificarPaciente_Click" Text="Modificar Paciente" CssClass="btn-enviar" runat="server" />
            </div>

        </div>
    </div>
</asp:Content>
