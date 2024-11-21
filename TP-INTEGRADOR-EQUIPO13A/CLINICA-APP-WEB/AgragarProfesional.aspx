<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AgragarProfesional.aspx.cs" Inherits="CLINICA_APP_WEB.AgragarProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="contenedor">
                <h1 class="titulo-principal">AGREGAR PROFESIONAL</h1>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
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
                            <asp:TextBox ID="txtFechaNac" CssClass="entrada-formulario" runat="server" placeholder="Fecha de nacimiento"  TextMode="Date"/>
       
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
                            <label for="txtFechaIngreso" class="etiqueta-formulario">Fecha de Ingreso:</label>
                            <asp:TextBox ID="txtFechaIngreso" CssClass="entrada-formulario" runat="server" placeholder="Fecha de ingreso"  TextMode="Date" />
            
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
                        <asp:Button ID="btnAgregarProfesional" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn-enviar" runat="server" />
                        <asp:HyperLink CssClass="enlace-formulario" NavigateUrl="BuscarProfesional.aspx" Text="Volver" runat="server"></asp:HyperLink>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
