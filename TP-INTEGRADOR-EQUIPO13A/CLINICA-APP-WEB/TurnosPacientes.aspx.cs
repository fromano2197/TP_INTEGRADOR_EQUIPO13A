using Dominio;
using Negocio;
using System;
using System.Data.SqlClient;
using System.Net.Mail;
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

                ddlInstitucion.Items.Insert(0, new ListItem("Selecciona una institución", "0"));
            }
            catch (Exception ex)
            {
                lblSuccess.Text = ex.Message;
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

                ddlEspecialidad.Items.Insert(0, new ListItem("Selecciona una especialidad", "0"));
            }
            catch (Exception ex)
            {
                lblSuccess.Text = ex.Message;
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
                lblSuccess.Text = ex.Message;
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

            if (!string.IsNullOrEmpty(institucion) && institucion != "0") consulta += " AND I.id_institucion = @institucion";
            if (!string.IsNullOrEmpty(especialidad) && especialidad != "0") consulta += " AND E.id_especialidad = @especialidad";
            if (!string.IsNullOrEmpty(medico) && medico != "0") consulta += " AND P.id_profesional = @medico";

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(consulta);

                if (!string.IsNullOrEmpty(institucion) && institucion != "0") datos.setearParametro("@institucion", institucion);
                if (!string.IsNullOrEmpty(especialidad) && especialidad != "0") datos.setearParametro("@especialidad", especialidad);
                if (!string.IsNullOrEmpty(medico) && medico != "0") datos.setearParametro("@medico", medico);

                datos.ejecutarLectura();
                gvTurnos.DataSource = datos.Lector;
                gvTurnos.DataBind();
            }
            catch (Exception ex)
            {
                lblSuccess.Text = ex.Message;
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
            ddlMedico.Items.Add(new ListItem("Selecciona un médico", "0"));

            if (idEspecialidad > 0 && idInstitucion > 0)
            {
                CargarMedicos(idEspecialidad, idInstitucion);
            }
            else
            {
                ddlMedico.Items.Add(new ListItem("Selecciona una especialidad e institución", "0"));
            }
        }

        private string ObtenerEmailPaciente(int idPaciente)
        {
            string email = string.Empty;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT email FROM PACIENTES WHERE id_paciente = @idPaciente";
                datos.setConsulta(consulta);
                datos.setearParametro("@idPaciente", idPaciente);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    email = datos.Lector["email"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "Error al obtener el email del paciente: " + ex.Message;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return email;
        }

        private void EnviarCorreoConfirmacion(string emailPaciente, string fecha, string hora, string medico, string especialidad, string institucion)
        {
            try
            {
                DateTime fechaDateTime = DateTime.Parse(fecha);
                string fechaFormateada = fechaDateTime.ToString("dd/MM/yyyy");
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("hernan39742374@gmail.com");
                correo.To.Add(emailPaciente);
                correo.Subject = "Confirmación de Turno";
                correo.Body = $"Estimado paciente,\n\nSu turno ha sido reservado exitosamente.\n\n" +
                              $"Detalles del turno:\n" +
                              $"- Fecha: {fechaFormateada}\n" +
                              $"- Hora: {hora}\n" +
                              $"- Médico: {medico}\n" +
                              $"- Especialidad: {especialidad}\n" +
                              $"- Institución: {institucion}\n\n" +
                              "Gracias por elegir nuestra clínica.";

                SmtpClient cliente = new SmtpClient("smtp.gmail.com");
                cliente.Port = 587;
                cliente.Credentials = new System.Net.NetworkCredential("hernan39742374@gmail.com", "lbwwgljjoqxnbxqo");
                cliente.EnableSsl = true;

                cliente.Send(correo);
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "Error al enviar el correo de confirmación: " + ex.Message;
                lblSuccess.Visible = true;
            }
        }

        private int ObtenerIdPacienteDesdeSesion()
        {
            if (Session["IdPaciente"] != null)
            {
                return Convert.ToInt32(Session["IdPaciente"]);
            }
            else
            {
                throw new Exception("No se encontró un paciente en sesión.");
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
                CargarTurnos();
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "Error al tomar el turno: " + ex.Message;
                lblSuccess.Visible = true;
            }
        }

        public void TomarTurno(int idTurno, int idPaciente)
        {
            try
            {
                string query = "UPDATE TURNOS SET id_paciente = @idPaciente, estado = 'reservado' WHERE id_turno = @idTurno1";
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta(query);
                datos.setearParametro("@idPaciente", idPaciente);
                datos.setearParametro("@idTurno1", idTurno);
                datos.ejecutarAccion();
                CargarTurnos();
                lblSuccess.Text = "¡El turno ha sido reservado exitosamente!";
                lblSuccess.Visible = true;

                string consultaTurno = @"SELECT T.fecha, T.hora, P.nombre + ' ' + P.apellido AS Medico, 
                                                E.nombre AS Especialidad, I.nombre AS Institucion
                                         FROM TURNOS T
                                         INNER JOIN profesionales P ON P.id_profesional = T.id_profesional
                                         INNER JOIN especialidades E ON E.id_especialidad = T.id_especialidad
                                         INNER JOIN instituciones I ON I.id_institucion = T.id_institucion
                                         WHERE T.id_turno = @idTurno";
                datos.setConsulta(consultaTurno);
                datos.setearParametro("@idTurno", idTurno);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    string fecha = datos.Lector["fecha"].ToString();
                    string hora = datos.Lector["hora"].ToString();
                    string medico = datos.Lector["Medico"].ToString();
                    string especialidad = datos.Lector["Especialidad"].ToString();
                    string institucion = datos.Lector["Institucion"].ToString();

                    string emailPaciente = ObtenerEmailPaciente(idPaciente);

                    EnviarCorreoConfirmacion(emailPaciente, fecha, hora, medico, especialidad, institucion);
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "Error al tomar el turno: " + ex.Message;
                lblSuccess.Visible = true;
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
                lblSuccess.Text = ex.Message;
                lblSuccess.Visible = true;
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

        protected void timerMensaje_Tick(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            timerMensaje.Enabled = false;
        }


    }
}
