<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisEstudios.aspx.cs" Inherits="CLINICA_APP_WEB.MisEstudios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="styles.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contenedor-estudios">
        <h1 class="titulo-resultados">Resultados de estudios</h1>

  
        <asp:GridView ID="gvEstudios" runat="server" AutoGenerateColumns="False" CssClass="table" 
                      OnRowCommand="gvEstudios_RowCommand">
            <Columns>
 
                <asp:BoundField DataField="tipo_estudio" HeaderText="Tipo de Estudio" SortExpression="tipo_estudio" />
                

                <asp:BoundField DataField="fecha_estudio" HeaderText="Fecha de Estudio" SortExpression="fecha_estudio" 
                                DataFormatString="{0:dd/MM/yyyy}" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDescargar" runat="server" Text="Descargar" CommandName="Descargar" 
                                    CommandArgument='<%# Eval("id_estudio") %>' CssClass="btn btn-primary" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
