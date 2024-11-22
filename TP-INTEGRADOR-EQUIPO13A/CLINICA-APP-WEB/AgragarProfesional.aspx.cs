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



        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtFechaNac.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                    string.IsNullOrWhiteSpace(txtFechaIngreso.Text) ||
                    string.IsNullOrWhiteSpace(txtMatricula.Text))
                {
                    lblMensaje.Text = "Todos los campos son obligatorios.";
                    lblMensaje.Visible = true;
                    return;
                }
                ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
                if (profesionalNegocio.ExisteUsuario(txtUsuario.Text, txtDni.Text))
                {
                    lblMensaje.Text = "El usuario o el DNI ya están registrados.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!long.TryParse(txtDni.Text, out _))
                {
                    lblMensaje.Text = "El DNI debe ser numérico.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                {
                    lblMensaje.Text = "El nombre solo puede contener letras y espacios.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtApellido.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
                {
                    lblMensaje.Text = "El apellido solo puede contener letras y espacios.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!DateTime.TryParseExact(txtFechaNac.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaNacimiento) || fechaNacimiento > DateTime.Now)
                {
                    lblMensaje.Text = "La fecha de nacimiento no es válida o es futura.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    lblMensaje.Text = "El correo electrónico no tiene un formato válido.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!long.TryParse(txtTelefono.Text, out _))
                {
                    lblMensaje.Text = "El teléfono debe ser numérico.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDireccion.Text))
                {
                    lblMensaje.Text = "La dirección es obligatoria.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (txtContraseña.Text.Length < 8 ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtContraseña.Text, @"[A-Z]") ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtContraseña.Text, @"[a-z]") ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtContraseña.Text, @"[0-9]"))
                {
                    lblMensaje.Text = "La contraseña debe tener al menos 8 caracteres, incluyendo una mayúscula, una minúscula y un número.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (!DateTime.TryParseExact(txtFechaIngreso.Text, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime fechaIngreso))
                {
                    lblMensaje.Text = "La fecha de ingreso no es válida.";
                    lblMensaje.Visible = true;
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMatricula.Text))
                {
                    lblMensaje.Text = "La matrícula es obligatoria.";
                    lblMensaje.Visible = true;
                    return;
                }


                if (string.IsNullOrWhiteSpace(ddlInstituciones.SelectedValue) ||
                    !int.TryParse(ddlInstituciones.SelectedValue, out int idInstitucion) ||
                    idInstitucion <= 0)
                {
                    lblMensaje.Text = "Debes seleccionar una institución válida de la lista.";
                    lblMensaje.Visible = true;
                    return;
                }


                if (string.IsNullOrWhiteSpace(ddlEspecialidades.SelectedValue) ||
                    !int.TryParse(ddlEspecialidades.SelectedValue, out int idEspecialidad) ||
                    idEspecialidad <= 0)
                {
                    lblMensaje.Text = "Debes seleccionar una especialidad válida de la lista.";
                    lblMensaje.Visible = true;
                    return;
                }


                Profesional aux = new Profesional();
                ProfesionalNegocio negocio = new ProfesionalNegocio();

                aux.Persona.Dni = txtDni.Text;
                aux.Persona.Nombre = txtNombre.Text;
                aux.Persona.Apellido = txtApellido.Text;
                aux.Persona.FechaNacimiento = fechaNacimiento;
                aux.Persona.ContactoCliente.Email = txtEmail.Text;
                aux.Persona.ContactoCliente.telefono = txtTelefono.Text;
                aux.Persona.ContactoCliente.Direccion = txtDireccion.Text;
                aux.Usuario.User = txtUsuario.Text;
                aux.Usuario.Password = txtContraseña.Text;
                aux.Usuario.tipousuario = "Profesional";
                aux.FechaIngreso = fechaIngreso;
                aux.Matricula = txtMatricula.Text;
                aux.Institucion.Add(new Institucion
                {
                    IdInstitucion = idInstitucion,
                    Nombre = ddlInstituciones.SelectedItem.Text
                });
           
                aux.Especialidad.IdEspecialidad = idEspecialidad;
                aux.Especialidades.Add(new Especialidad
                {
                    IdEspecialidad = idEspecialidad,
                    NombreEspecialidad = ddlEspecialidades.SelectedItem.Text
                });

                negocio.Agregar(aux);

                Response.Redirect("BuscarProfesional.aspx", false);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                lblMensaje.Visible = true;
            }
        }

    }
}