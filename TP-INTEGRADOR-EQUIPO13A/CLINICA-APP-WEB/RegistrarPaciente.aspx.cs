using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CLINICA_APP_WEB
{
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Paciente paciente = new Paciente();
                Usuario usuario = new Usuario();
                PacienteNegocio pacienteNegocio = new PacienteNegocio();

                // Inicializa los datos del paciente
                paciente.DatosPersona.Dni = int.Parse(txtDni.Text);
                paciente.DatosPersona.Nombre = txtNombre.Text;
                paciente.DatosPersona.Apellido = txtApellido.Text;
                paciente.DatosPersona.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                paciente.DatosPersona.ContactoCliente.Email = txtEmail.Text;
                paciente.DatosPersona.ContactoCliente.telefono = txtTelefono.Text;
                paciente.DatosPersona.ContactoCliente.Direccion = txtDireccion.Text;
                usuario.User = txtUsuario.Text;
                usuario.Password = txtPass.Text;

                pacienteNegocio.nuevoPaciente(paciente, usuario);

                lblMensaje.Text = "Registro exitoso. Serás redirigido a la página principal.";
                lblMensaje.Visible = true;
                 
                string script = "setTimeout(function() { window.location.href = 'default.aspx'; }, 3000);"; 
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