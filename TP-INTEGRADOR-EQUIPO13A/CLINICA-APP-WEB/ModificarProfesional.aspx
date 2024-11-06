<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarProfesional.aspx.cs" Inherits="CLINICA_APP_WEB.ModificarProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor">
        <h1 class="titulo-principal">MODIFICAR PROFESIONAL</h1>

        <div class="contenedor-formulario">
            <div class="grid-formulario">
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
                    <asp:Calendar ID="calFechaNac" runat="server"  Visible="false" />
                    <asp:Button ID="btnMostrarCalendario" runat="server" Text="Seleccionar Fecha"  />
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
                    <label for="txtUsuario" class="etiqueta-formulario">Usuario:</label>
                    <asp:TextBox ID="txtUsuario" CssClass="entrada-formulario" runat="server" placeholder="Usuario" />
                </div>
                <div class="grupo-formulario">
                    <label for="txtContraseña" class="etiqueta-formulario">Contraseña:</label>
                    <asp:TextBox ID="txtContraseña" CssClass="entrada-formulario" runat="server" placeholder="Contraseña" />
                </div>
                <div class="grupo-formulario">
                    <label for="txtTipoUsuario" class="etiqueta-formulario">Tipo Usuario:</label>
                    <asp:TextBox ID="txtTipoUsuario" CssClass="entrada-formulario" runat="server" placeholder="Tipo Usuario" />
                </div>

                <div class="grupo-formulario">
                    <label for="txtFechaIngreso" class="etiqueta-formulario">Fecha de Ingreso:</label>
                    <asp:TextBox ID="txtFechaIngreso" CssClass="entrada-formulario" runat="server" placeholder="Fecha de ingreso" />
                    <asp:Calendar ID="calFechaIngreso" runat="server"  Visible="false" />
                    <asp:Button ID="btnMostrarCalendarioIngreso" runat="server" Text="Seleccionar Fecha"  />
                </div>

                <div class="grupo-formulario">
                    <label for="txtMatricula" class="etiqueta-formulario">Matrícula:</label>
                    <asp:TextBox ID="txtMatricula" CssClass="entrada-formulario" runat="server" placeholder="Matrícula" />
                </div>

                <div class="grupo-formulario">
                    <label class="etiqueta-formulario">Institución:</label>
                    <asp:DropDownList ID="ddlInstituciones" CssClass="entrada-formulario" runat="server" />
                </div>

                <div class="grupo-formulario">
                    <label class="etiqueta-formulario">Especialidades:</label>
                    <asp:DropDownList ID="ddlEspecialidades" CssClass="entrada-formulario" runat="server" />
                </div>
            </div>

            <div>
                <asp:Button ID="btnModificarProfesional" Text="Modificar"  CssClass="btn-enviar" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>