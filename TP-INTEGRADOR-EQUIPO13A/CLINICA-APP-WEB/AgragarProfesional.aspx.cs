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
    public partial class AgragarProfesional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                calFechaNac.Visible = false;
                calFechaIngreso.Visible = false;
                CargarEspecialidades();
                CargarInstituciones();
            }
        }
        private void CargarEspecialidades()
        {
            ProfesionalNegocio negocio = new ProfesionalNegocio();
            var especialidades = negocio.obtenerEspecialidades();

            ddlEspecialidades.DataSource = especialidades;
            ddlEspecialidades.DataTextField = "NombreEspecialidad";
            ddlEspecialidades.DataValueField = "IdEspecialidad";
            ddlEspecialidades.DataBind();

            ddlEspecialidades.Items.Insert(0, new ListItem("-- Seleccionar Especialidad --", ""));
        }

        private void CargarInstituciones()
        {
            ProfesionalNegocio negocio = new ProfesionalNegocio();
            var instituciones = negocio.obtenerInstituciones();

            ddlInstituciones.DataSource = instituciones;
            ddlInstituciones.DataTextField = "Nombre";
            ddlInstituciones.DataValueField = "IdInstitucion";
            ddlInstituciones.DataBind();

            ddlInstituciones.Items.Insert(0, new ListItem("-- Seleccionar Institución --", ""));
        }



        protected void btnMostrarCalendario_Click(object sender, EventArgs e)
        {

            calFechaNac.Visible = !calFechaNac.Visible;

        }
        protected void btnMostrarCalendarioIngreso_Click(object sender, EventArgs e)
        {
            calFechaIngreso.Visible = !calFechaIngreso.Visible;

        }


        protected void calFechaNac_SelectionChanged(object sender, EventArgs e)
        {

            txtFechaNac.Text = calFechaNac.SelectedDate.ToString("dd/MM/yyyy");

            calFechaNac.Visible = false;
        }

        protected void calFechaIngreso_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaIngreso.Text = calFechaIngreso.SelectedDate.ToString("dd/MM/yyyy");
            calFechaIngreso.Visible = false;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Profesional aux = new Profesional();
            ProfesionalNegocio negocio = new ProfesionalNegocio();
            aux.Persona.Dni =txtDni.Text;
            aux.Persona.Nombre = txtNombre.Text;
            aux.Persona.Apellido = txtApellido.Text;
            aux.Persona.FechaNacimiento = DateTime.ParseExact(txtFechaNac.Text, "dd/MM/yyyy", null);
            aux.Persona.ContactoCliente.Email = txtEmail.Text;
            aux.Persona.ContactoCliente.telefono = txtTelefono.Text;
            aux.Persona.ContactoCliente.Direccion = txtDireccion.Text;
            aux.Usuario.User = txtUsuario.Text;
            aux.Usuario.Password = txtContraseña.Text;
            aux.Usuario.tipousuario = txtTipoUsuario.Text;
            aux.FechaIngreso = DateTime.ParseExact(txtFechaIngreso.Text, "dd/MM/yyyy", null);
            aux.Matricula = txtMatricula.Text;
            aux.Institucion.IdInstitucion = int.Parse(ddlInstituciones.SelectedValue);
            aux.Institucion.Nombre = ddlInstituciones.SelectedItem.Text;
            aux.Especialidad.IdEspecialidad = int.Parse(ddlEspecialidades.SelectedValue);
            aux.Especialidades.Add(new Especialidad
            {
                IdEspecialidad = int.Parse(ddlEspecialidades.SelectedValue),
                NombreEspecialidad = ddlEspecialidades.SelectedItem.Text
            });

            negocio.Agregar(aux);
            Response.Redirect("BuscarProfesional.aspx", false);

        }

    }
}