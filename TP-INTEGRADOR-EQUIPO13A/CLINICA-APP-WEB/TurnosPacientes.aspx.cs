using Dominio;
using Negocio;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class TurnosPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarInstituciones();
                CargarEspecialidades();
            }
        }

        private void CargarInstituciones()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT id_institucion, nombre FROM instituciones WHERE activo = 1");
                datos.ejecutarLectura();
                ddlInstitucion.DataSource = datos.Lector;
                ddlInstitucion.DataTextField = "nombre";
                ddlInstitucion.DataValueField = "id_institucion";
                ddlInstitucion.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private void CargarEspecialidades()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT id_especialidad, nombre FROM especialidades WHERE activo = 1");
                datos.ejecutarLectura();
                ddlEspecialidad.DataSource = datos.Lector;
                ddlEspecialidad.DataTextField = "nombre";
                ddlEspecialidad.DataValueField = "id_especialidad";
                ddlEspecialidad.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private void CargarMedicos(int idEspecialidad, int idInstitucion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT distinct(P.id_profesional), P.nombre + ' ' + P.apellido AS Medico " +
                                  "FROM TURNOS T " +
                                  "INNER JOIN profesionales P ON P.id_profesional = T.id_profesional " +
                                  "INNER JOIN especialidades E ON E.id_especialidad = T.id_especialidad " +
                                  "INNER JOIN instituciones I ON I.id_institucion = T.id_institucion " +
                                  "WHERE T.estado = 'disponible' AND P.activo = 1 AND E.activo = 1 AND I.activo = 1 " +
                                  "AND T.id_especialidad = @idEspecialidad AND T.id_institucion = @idInstitucion";

                datos.setConsulta(consulta);
                datos.setearParametro("@idEspecialidad", idEspecialidad);
                datos.setearParametro("@idInstitucion", idInstitucion);
                datos.ejecutarLectura();
                ddlMedico.Items.Clear();
                ddlMedico.Items.Add(new ListItem("Selecciona un médico", "0"));
                while (datos.Lector.Read())
                {
                    string nombreCompleto = datos.Lector["Medico"].ToString();
                    string idMedico = datos.Lector["id_profesional"].ToString();
                    ddlMedico.Items.Add(new ListItem(nombreCompleto, idMedico));
                }
                if (ddlMedico.Items.Count == 1)
                {
                    ddlMedico.Items.Add(new ListItem("No hay médicos disponibles", "0"));
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        protected void btnConsultarTurnos_Click(object sender, EventArgs e)
        {
            string institucion = ddlInstitucion.SelectedValue;
            string especialidad = ddlEspecialidad.SelectedValue;
            string medico = ddlMedico.SelectedValue;

            string consulta = @"SELECT P.nombre + ' ' + P.apellido AS Medico, E.nombre AS especialidad, T.id_turno, T.id_paciente, T.id_profesional, T.id_especialidad, T.id_institucion, T.fecha, T.hora, I.nombre as institucion, T.estado
                     FROM TURNOS T
                     INNER JOIN profesionales P ON P.id_profesional = T.id_profesional
                     INNER JOIN especialidades E ON E.id_especialidad = T.id_especialidad
                     INNER JOIN instituciones I ON I.id_institucion = T.id_institucion
                     WHERE T.estado = 'disponible' AND P.activo = 1 AND E.activo = 1 AND I.activo = 1";

            if (!string.IsNullOrEmpty(institucion)) consulta += " AND I.id_institucion = @institucion";
            if (!string.IsNullOrEmpty(especialidad)) consulta += " AND E.id_especialidad = @especialidad";
            if (!string.IsNullOrEmpty(medico)) consulta += " AND P.id_profesional = @medico";

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(consulta);
                if (!string.IsNullOrEmpty(institucion)) datos.setearParametro("@institucion", institucion);
                if (!string.IsNullOrEmpty(especialidad)) datos.setearParametro("@especialidad", especialidad);
                if (!string.IsNullOrEmpty(medico)) datos.setearParametro("@medico", medico);

                datos.ejecutarLectura();
                gvTurnos.DataSource = datos.Lector;
                gvTurnos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);
            int idInstitucion = int.Parse(ddlInstitucion.SelectedValue);

            ddlMedico.Items.Clear();

            if (idEspecialidad > 0 && idInstitucion > 0)
            {
                CargarMedicos(idEspecialidad, idInstitucion); 
            }
            else
            {
                ddlMedico.Items.Add(new ListItem("Selecciona una especialidad e institución", "0"));
            }
        }

        protected void btnTomarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                
                int idPaciente = Convert.ToInt32(Session["idPaciente"]);
                if (idPaciente == 0)
                {
                    throw new Exception("El paciente no está registrado.");
                }

                Button btn = (Button)sender;
                int idTurno = Convert.ToInt32(btn.CommandArgument);

                TomarTurno(idTurno, idPaciente);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al tomar el turno: " + ex.Message;
                lblError.Visible = true;
            }
        }


        public void TomarTurno(int idTurno, int idPaciente)
        {
            try
            {
                string query = "UPDATE TURNOS SET id_paciente = @idPaciente, estado = 'reservado' WHERE id_turno = @idTurno";
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta(query);
                datos.setearParametro("@idPaciente", idPaciente);
                datos.setearParametro("@idTurno", idTurno);
                datos.ejecutarAccion();
                CargarTurnos();
                lblError.Text = "El turno ha sido reservado exitosamente.";
                lblError.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al tomar el turno: " + ex.Message;
                lblError.Visible = true;
            }
        }




        private void CargarTurnos()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"SELECT P.nombre + ' ' + P.apellido AS Medico, E.nombre AS especialidad, T.id_turno, T.id_paciente, T.id_profesional, T.id_especialidad, T.id_institucion, T.fecha, T.hora, I.nombre as institucion, T.estado
                            FROM TURNOS T
                            INNER JOIN profesionales P ON P.id_profesional = T.id_profesional
                            INNER JOIN especialidades E ON E.id_especialidad = T.id_especialidad
                            INNER JOIN instituciones I ON I.id_institucion = T.id_institucion
                            WHERE T.estado = 'disponible' AND P.activo = 1 AND E.activo = 1 AND I.activo = 1";
                datos.setConsulta(consulta);
                datos.ejecutarLectura();
                gvTurnos.DataSource = null;
                gvTurnos.DataSource = datos.Lector;
                gvTurnos.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btnTomarTurno = (Button)e.Row.FindControl("btnTomarTurno");
                if (btnTomarTurno != null)
                {
                    string estado = DataBinder.Eval(e.Row.DataItem, "estado").ToString();
                    btnTomarTurno.Visible = estado == "disponible";
                }
            }
        }



    }
}
