using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class AdministrarTurnos : System.Web.UI.Page
    {
        TurnoNegocio turnoNegocio = new TurnoNegocio();

  

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDowns();
                CargarHoras();
                CargarTurnos();
            }
        }

        private void CargarDropDowns()
        {
            ddlProfesionales.DataSource = ObtenerProfesionales();
            ddlProfesionales.DataTextField = "NombreCompleto";
            ddlProfesionales.DataValueField = "IdProfesional";
            ddlProfesionales.DataBind();
            ddlProfesionales.Items.Insert(0, new ListItem("Seleccione un profesional", "0"));

            ddlEspecialidades.DataSource = ObtenerEspecialidades();
            ddlEspecialidades.DataTextField = "NombreEspecialidad";
            ddlEspecialidades.DataValueField = "IdEspecialidad";
            ddlEspecialidades.DataBind();
            ddlEspecialidades.Items.Insert(0, new ListItem("Seleccione una especialidad", "0"));

            ddlInstituciones.DataSource = ObtenerInstituciones();
            ddlInstituciones.DataTextField = "Nombre";
            ddlInstituciones.DataValueField = "IdInstitucion";
            ddlInstituciones.DataBind();
            ddlInstituciones.Items.Insert(0, new ListItem("Seleccione una institución", "0"));
        }

        private List<Profesional> ObtenerProfesionales()
        {
            ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
            return profesionalNegocio.listarProfesionales();
        }

        private List<Especialidad> ObtenerEspecialidades()
        {
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            return especialidadNegocio.listar();
        }

        private List<Institucion> ObtenerInstituciones()
        {
            InstitucionNegocio institucionNegocio = new InstitucionNegocio();
            return institucionNegocio.listar();
        }

        private void CargarTurnos()
        {
            var turnos = turnoNegocio.listarTurnos().Select(t => new Turno
            {
                id_profesional = t.id_profesional,
                id_especialidad = t.id_especialidad,
                IdInstitucion = t.IdInstitucion,
                Institucion = t.Institucion,
                Fecha = t.Fecha,
                Hora = t.Hora,
                Profesional = new Profesional
                {
                    IdProfesional = t.id_profesional,
                    Persona = new Persona
                    {
                        Nombre = t.Profesional.Persona.Nombre,
                        Apellido = t.Profesional.Persona.Apellido
                    }
                },
                Especialidad = new Especialidad
                {
                    NombreEspecialidad = t.Especialidad.NombreEspecialidad
                }
            }).ToList();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selección de hora
                if (ddlHora.SelectedValue == "0")
                {
                    throw new Exception("Debe seleccionar una hora válida.");
                }

                turnoNegocio.CrearTurno(
                    int.Parse(ddlProfesionales.SelectedValue),
                    int.Parse(ddlEspecialidades.SelectedValue),
                    DateTime.Parse(txtFecha.Text),
                    TimeSpan.Parse(ddlHora.SelectedValue), // Usar SelectedValue para obtener el valor
                    int.Parse(ddlInstituciones.SelectedValue)
                );

                CargarTurnos();
                LimpiarFormulario();
                Response.Redirect("PortalTurnos.aspx", false);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idTurno = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Editar")
            {
                // Lógica para editar
            }
            else if (e.CommandName == "Eliminar")
            {
                turnoNegocio.EliminarTurno(idTurno);
                CargarTurnos();
            }
        }

        private void LimpiarFormulario()
        {
            txtIdTurno.Text = string.Empty;
            ddlProfesionales.SelectedIndex = 0;
            ddlEspecialidades.SelectedIndex = 0;
            ddlInstituciones.SelectedIndex = 0;
            txtFecha.Text = string.Empty;
            ddlHora.SelectedIndex = 0; // Limpiar selección de hora
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        protected void ddlProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProfesional = int.Parse(ddlProfesionales.SelectedValue);

            if (idProfesional > 0)
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                ddlEspecialidades.DataSource = especialidadNegocio.ObtenerEspecialidadesPorProfesional(idProfesional);
                ddlEspecialidades.DataTextField = "NombreEspecialidad";
                ddlEspecialidades.DataValueField = "IdEspecialidad";
                ddlEspecialidades.DataBind();
                ddlEspecialidades.Items.Insert(0, new ListItem("Seleccione una especialidad", "0"));

                InstitucionNegocio institucionNegocio = new InstitucionNegocio();
                ddlInstituciones.DataSource = institucionNegocio.ObtenerInstitucionesPorProfesional(idProfesional);
                ddlInstituciones.DataTextField = "Nombre";
                ddlInstituciones.DataValueField = "IdInstitucion";
                ddlInstituciones.DataBind();
                ddlInstituciones.Items.Insert(0, new ListItem("Seleccione una institución", "0"));
            }
            else
            {
                ddlEspecialidades.Items.Clear();
                ddlEspecialidades.Items.Insert(0, new ListItem("Seleccione una especialidad", "0"));

                ddlInstituciones.Items.Clear();
                ddlInstituciones.Items.Insert(0, new ListItem("Seleccione una institución", "0"));
            }
        }

        private void CargarHoras()
        {
            ddlHora.Items.Clear();
            DateTime inicio = DateTime.Today.AddHours(7); // Hora inicial (7:00 AM)
            DateTime fin = DateTime.Today.AddHours(20); // Hora final (8:00 PM)

            while (inicio <= fin)
            {
                ddlHora.Items.Add(new ListItem(inicio.ToString("HH:mm"), inicio.ToString("HH:mm")));
                inicio = inicio.AddMinutes(30); // Incrementar en intervalos de 30 minutos
            }

            ddlHora.Items.Insert(0, new ListItem("Seleccione una hora", "0"));
        }
    }
}
