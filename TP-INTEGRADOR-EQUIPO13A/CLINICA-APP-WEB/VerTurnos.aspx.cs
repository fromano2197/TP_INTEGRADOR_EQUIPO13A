using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class VerTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTurnos();
            }
        }

        private void CargarTurnos(string filtro = "")
        {
            string consulta = @"
                SELECT 
                    T.id_turno,
                    ISNULL(T.id_paciente,'0') AS id_paciente,
                    T.id_profesional,
                    T.id_especialidad,
                    T.id_institucion,
                    ISNULL(P.nombre,'No asignado') as nombre_paciente,
                    ISNULL(P.apellido,'No asignado') apellido_paciente,
                    PR.nombre,
                    PR.apellido,
                    E.Nombre AS Especialidad,
                    I.nombre AS Institucion,
                    CAST(T.Fecha AS DATE) AS Fecha,
                    T.Hora,
                    T.Estado,
                    ISNULL(T.Observaciones,'Sin Observación') as observacion
                FROM Turnos T
                LEFT JOIN Pacientes P ON T.id_paciente = P.id_paciente
                LEFT JOIN Profesionales PR ON T.id_profesional = PR.id_profesional
                LEFT JOIN Especialidades E ON T.id_especialidad = E.id_especialidad
                LEFT JOIN Instituciones I ON I.id_institucion = T.id_institucion";

            if (!string.IsNullOrEmpty(filtro))
            {
                consulta += " WHERE P.nombre LIKE @FILTRO OR T.Estado LIKE @FILTRO OR P.apellido LIKE @FILTRO OR CAST(P.dni AS NVARCHAR) LIKE @FILTRO OR PR.nombre LIKE @FILTRO OR PR.apellido LIKE @FILTRO OR CONVERT(VARCHAR, T.Fecha, 103) LIKE @FILTRO ";
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
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();

            datos.cerrarConexion();
        }


        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = DataBinder.Eval(e.Row.DataItem, "Estado").ToString();

                if (estado.Equals("atendido", StringComparison.OrdinalIgnoreCase))
                {
                    e.Row.BackColor = System.Drawing.Color.Honeydew;
                    e.Row.Font.Bold = true;
                }
                if (estado.Equals("reservado", StringComparison.OrdinalIgnoreCase))
                {
                    e.Row.BackColor = System.Drawing.Color.Moccasin;
                    e.Row.Font.Bold = true;
                }
                if (estado.Equals("cancelado", StringComparison.OrdinalIgnoreCase))
                {
                    e.Row.BackColor = System.Drawing.Color.LavenderBlush;
                    e.Row.Font.Bold = true;
                }


            }
        }


        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int idTurno = Convert.ToInt32(gvTurnos.DataKeys[index].Value);
            if (e.CommandName == "CancelarTurno")
            {
                try
                {
                    EliminarTurno(idTurno);
                    lblError.Text = "El turno ha sido eliminado✅";
                    lblError.CssClass = "text-success";
                    lblError.Visible = true;
                    timerMensaje.Enabled = true;
                    CargarTurnos();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error al eliminar turno: " + ex.Message;
                    lblError.CssClass = "text-danger1";
                    lblError.Visible = true;
                    timerMensaje.Enabled = true;
                }
            }
            if (e.CommandName == "AsignarTurno")
            {
                Response.Redirect($"AsignarTurno.aspx?id_turno={idTurno}");
            }
        }





        private void EliminarTurno(int idTurno)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta = "DELETE FROM TURNOS WHERE id_turno = @idTurno";

            try
            {
                datos.setConsulta(consulta);
                datos.setearParametro("@idTurno", idTurno);
                datos.ejecutarAccion();
            }
            catch
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarTurno.Text.Trim();
            CargarTurnos(filtro);
        }


        protected void timerMensaje_Tick(object sender, EventArgs e)
        {
            lblError.Visible = false;
            timerMensaje.Enabled = false;
        }

    }
}