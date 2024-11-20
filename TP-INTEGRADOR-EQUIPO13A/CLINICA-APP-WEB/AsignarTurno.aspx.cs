using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;

namespace CLINICA_APP_WEB
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idTurno;
                if (int.TryParse(Request.QueryString["id_turno"], out idTurno))
                {
                    ViewState["id_turno"] = idTurno;
                    CargarPacientes();
                }
                else
                {
                    lblError.Text = "Turno no válido.";
                    lblError.Visible = true;
                }
            }
        }

        private void CargarPacientes()
        {
            string consulta = "SELECT id_paciente, nombre, apellido, dni FROM pacientes";
            AccesoDatos datos = new AccesoDatos();
            datos.setConsulta(consulta);
            datos.ejecutarLectura();

            DataTable dt = new DataTable();
            dt.Load(datos.Lector);
            gvPacientes.DataSource = dt;
            gvPacientes.DataBind();

            datos.cerrarConexion();
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AsignarPaciente")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int idPaciente = Convert.ToInt32(gvPacientes.DataKeys[rowIndex].Value);
                int idTurno = (int)ViewState["id_turno"];

                AsignarTurnoAPaciente(idTurno, idPaciente);
            }
        }

        private void AsignarTurnoAPaciente(int idTurno, int idPaciente)
        {
            string consulta = "UPDATE turnos SET id_paciente = @IDPACIENTE, estado = 'reservado' WHERE id_turno = @IDTURNO";
            AccesoDatos datos = new AccesoDatos();
            datos.setConsulta(consulta);
            datos.setearParametro("@IDPACIENTE", idPaciente);
            datos.setearParametro("@IDTURNO", idTurno);

            try
            {
                datos.ejecutarAccion();
                lblMensaje.Text = "Turno asignado correctamente.";
                lblMensaje.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al asignar el turno: " + ex.Message;
                lblError.Visible = true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        private void CargarPacientes(string filtro = "")
        {
            string consulta = "SELECT id_paciente, nombre, apellido, dni FROM pacientes";

            if (!string.IsNullOrEmpty(filtro))
            {
                consulta += " WHERE nombre LIKE @FILTRO OR apellido LIKE @FILTRO OR CAST(dni AS NVARCHAR) LIKE @FILTRO";
            }

            AccesoDatos datos = new AccesoDatos();
            datos.setConsulta(consulta);

            if (!string.IsNullOrEmpty(filtro))
            {
                datos.setearParametro("@FILTRO", "%" + filtro + "%");
            }

            datos.ejecutarLectura();

            DataTable dt = new DataTable();
            dt.Load(datos.Lector);
            gvPacientes.DataSource = dt;
            gvPacientes.DataBind();

            datos.cerrarConexion();
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarPaciente.Text.Trim();
            CargarPacientes(filtro);
        }

    }
}

