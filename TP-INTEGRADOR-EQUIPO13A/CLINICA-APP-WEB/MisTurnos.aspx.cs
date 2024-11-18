using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class MisTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPaciente"] != null)
                {
                    int idPaciente = Convert.ToInt32(Session["idPaciente"]);
                    CargarTurnos(idPaciente);
                }
                else
                {
                    lblError.Text = "No se encontró un paciente en la sesión.";
                    lblError.Visible = true;
                }
            }
        }

        private void CargarTurnos(int idPaciente)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta = @"
        SELECT 
            T.id_turno,
            P.nombre + ' ' + P.apellido AS Medico,
            E.nombre AS Especialidad,
            T.fecha,
            T.hora,
            I.nombre AS Institucion,
            I.direccion AS Direccion
        FROM TURNOS T
        INNER JOIN profesionales P ON P.id_profesional = T.id_profesional
        INNER JOIN especialidades E ON E.id_especialidad = T.id_especialidad
        INNER JOIN instituciones I ON I.id_institucion = T.id_institucion
        WHERE T.estado = 'reservado' 
          AND T.id_paciente = @idPaciente
          AND T.fecha >= GETDATE()";

            try
            {
                datos.setConsulta(consulta);
                datos.setearParametro("@idPaciente", idPaciente);
                datos.ejecutarLectura();

                DataTable dtTurnos = new DataTable();
                dtTurnos.Load(datos.Lector);

                gvTurnos.DataSource = dtTurnos;
                gvTurnos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar los turnos: " + ex.Message;
                lblError.Visible = true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CancelarTurno")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvTurnos.Rows[index];
                int idTurno = Convert.ToInt32(gvTurnos.DataKeys[index]["id_turno"]);

                try
                {
                    CancelarTurno(idTurno);

                    lblError.Text = "El turno ha sido cancelado y está disponible nuevamente.";
                    lblError.CssClass = "text-success";
                    lblError.Visible = true;

                    CargarTurnos((int)Session["idPaciente"]);
                }
                catch (Exception ex)
                {
                    lblError.Text = "Error al cancelar el turno: " + ex.Message;
                    lblError.CssClass = "text-danger";
                    lblError.Visible = true;
                }
            }
        }


        private void CancelarTurno(int idTurno)
        {
            AccesoDatos datos = new AccesoDatos();
            string consulta = "UPDATE TURNOS SET estado = 'disponible',id_paciente=NULL  WHERE id_turno = @idTurno";

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


    }
}