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
    public partial class AgregarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar1_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = new Paciente();
                Usuario usuario = new Usuario();
                PacienteNegocio pacienteNegocio = new PacienteNegocio();

                paciente.DatosPersona.Dni = txtDni.Text;
                paciente.DatosPersona.Nombre = txtNombre.Text;
                paciente.DatosPersona.Apellido = txtApellido.Text;
                paciente.DatosPersona.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                paciente.DatosPersona.ContactoCliente.Email = txtEmail.Text;
                paciente.DatosPersona.ContactoCliente.telefono = txtTelefono.Text;
                paciente.DatosPersona.ContactoCliente.Direccion = txtDireccion.Text;
                usuario.User = txtUsuario.Text;
                usuario.Password = txtPass.Text;

                pacienteNegocio.nuevoPaciente(paciente, usuario);

                lblMensaje.Text = "Registro exitoso.";
                lblMensaje.Visible = true;

                string script = "window.location.href = 'BuscarPaciente.aspx';";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirigir", script, true);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                lblMensaje.Text = "Ocurrió un error al registrar el paciente: " + ex.Message;
                lblMensaje.Visible = true;
            }
        }
    }
}