<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargarEstrudios.aspx.cs" Inherits="CLINICA_APP_WEB.CargarEstudios" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor-formulario3">
        <h2 class="titulo-formulario3">Cargar Estudio</h2>

        <label for="txtTipoEstudio" class="etiqueta-formulario3">Tipo de Estudio:</label>
        <asp:TextBox ID="txtTipoEstudio" runat="server" CssClass="campo-formulario3" />

        <div class="contenedor-archivo">
            <label for="FileUploadEstudio" class="etiqueta-formulario3">Seleccionar archivo:</label>
            <asp:FileUpload ID="FileUploadEstudio" runat="server" CssClass="campo-formulario3" />
        </div>

        <div class="botones">
            <asp:Button ID="btnCargarEstudio" runat="server" Text="Cargar Estudio" CssClass="boton3 boton-primario3" OnClick="btnCargarEstudio_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="boton3 boton-secundario3" OnClick="btnVolver_Click" />
        </div>

        <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje-formulario3" Visible="false"></asp:Label>
    </div>
</asp:Content>
