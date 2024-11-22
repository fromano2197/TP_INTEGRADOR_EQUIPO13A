<%@ Page Title="Turnos Pacientes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TurnosPacientes.aspx.cs" Inherits="CLINICA_APP_WEB.TurnosPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-container">
        <form class="space-y-4">
            <div class="form-group">
                <label for="ddlInstitucion" class="form-label">Institución:</label>
                <asp:DropDownList ID="ddlInstitucion" runat="server" CssClass="form-select">
                    <asp:ListItem Text="SELECCIONAR" Value="" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="ddlEspecialidad" class="form-label">Especialidad:</label>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                    <asp:ListItem Text="SELECCIONAR" Value="" Selected="True"></asp:ListItem> 
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="ddlMedico" class="form-label">Médico:</label>
                <asp:DropDownList ID="ddlMedico" runat="server" CssClass="form-select">
                    <asp:ListItem Text="SELECCIONAR" Value="" Selected="True"></asp:ListItem>                   
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnConsultarTurnos" runat="server" CssClass="btn-primary" Text="Consultar turnos disponibles" OnClick="btnConsultarTurnos_Click" />

            
        </form>
    </div>

    <hr />
    <asp:UpdatePanel ID="UpdatePanelTurnos" runat="server">
        <ContentTemplate>
            <div class="results-container">
                <asp:GridView ID="gvTurnos" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowDataBound="gvTurnos_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="Institucion" HeaderText="Institución" />
                        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" />
                        <asp:BoundField DataField="Medico" HeaderText="Médico" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Hora" HeaderText="Hora" />

                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:Button ID="btnTomarTurno" runat="server"
                                            Text="Tomar Turno"
                                            CommandName="TomarTurno"
                                            CommandArgument='<%# Eval("id_turno") %>'
                                            OnClick="btnTomarTurno_Click"
                                            CssClass="btn-especialidad visualizar"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" Visible="false"></asp:Label>
    <asp:Timer ID="timerMensaje" runat="server" OnTick="timerMensaje_Tick" Interval="3000" Enabled="false" />

</asp:Content>
