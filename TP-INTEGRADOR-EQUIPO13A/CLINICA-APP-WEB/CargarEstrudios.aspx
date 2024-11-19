<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CargarEstrudios.aspx.cs" Inherits="CLINICA_APP_WEB.CargarEstudios" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <h2>Cargar Estudio</h2>
        <label for="txtTipoEstudio">Tipo de Estudio:</label>
        <asp:TextBox ID="txtTipoEstudio" runat="server" CssClass="form-control" />

        <div class="file-upload-container">
            <label for="FileUploadEstudio">Seleccionar archivo:</label>
            <asp:FileUpload ID="FileUploadEstudio" runat="server" CssClass="form-control" />
        </div>

        <asp:Button ID="btnCargarEstudio" runat="server" Text="Cargar Estudio" CssClass="btn btn-primary" OnClick="btnCargarEstudio_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" Visible="false" />
    </div>
</asp:Content>
