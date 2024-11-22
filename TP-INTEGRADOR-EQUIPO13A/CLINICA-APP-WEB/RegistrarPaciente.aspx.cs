using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

                if (string.IsNullOrWhiteSpace(txtDni.Text) ||
                    string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtFechaNac.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                    string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    lblMensaje.Text = "Todos los campos son obligatorios.";
                    lblMensaje.Visible = true;
                    return;
                }

                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                if (pacienteNegocio.ExisteUsuario(txtUsuario.Text, txtDni.Text))
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


                if (!DateTime.TryParse(txtFechaNac.Text, out DateTime fechaNac) || fechaNac > DateTime.Now)
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


                if (txtPass.Text.Length < 8 ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtPass.Text, @"[A-Z]") ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtPass.Text, @"[a-z]") ||
                    !System.Text.RegularExpressions.Regex.IsMatch(txtPass.Text, @"[0-9]"))
                {
                    lblMensaje.Text = "La contraseña debe tener al menos 8 caracteres, incluyendo una mayúscula, una minúscula y un número.";
                    lblMensaje.Visible = true;
                    return;
                }


                Paciente paciente = new Paciente();
                Usuario usuario = new Usuario();

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

                lblMensaje.Text = "Registro exitoso. Serás redirigido a la página principal.";
                lblMensaje.Visible = true;


                EnviarCorreoConfirmacion(paciente.DatosPersona.ContactoCliente.Email);


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

        private void EnviarCorreoConfirmacion(string emailDestino)
        {
            try
            {
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("hernan39742374@gmail.com");
                mensaje.To.Add(emailDestino);
                mensaje.Subject = "Confirmación de registro";


                mensaje.Body = @"
                    <html>
                        <body style=""font-family: Arial, sans-serif; color: #333; text-align: center;"">
                            <h1 style=""color: #0056b3;"">¡Registro exitoso!</h1>
                            p>Gracias por registrarte en nuestra clínica. Tu registro ha sido exitoso.</p>
                            <p style=""margin-top: 20px;"">
                            <img src=""https://i.pinimg.com/236x/76/91/f8/7691f809425069fa599eb6137f4d6071.jpg"" 
                            alt=""Logotipo"" style=""width: 300px; height: auto; display: block; margin: 0 auto;"" />
                            </p>
                            <p>Si tienes alguna duda, no dudes en <a href=""mailto:hernan39742374@gmail.com"" style=""color: #0056b3;"">contactarnos</a>.</p>
                        </body>
                   </html>";
                mensaje.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("hernan39742374@gmail.com", "lbwwgljjoqxnbxqo");
                smtp.EnableSsl = true;

                smtp.Send(mensaje);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "El registro fue exitoso, pero ocurrió un problema al enviar el correo de confirmación.";
                lblMensaje.Visible = true;
            }
        }

    }
}