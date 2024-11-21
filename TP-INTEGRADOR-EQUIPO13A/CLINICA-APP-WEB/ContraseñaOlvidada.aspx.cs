using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class ContraseñaOlvidada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            if (int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                string mensaje = pacienteNegocio.RecuperarContraseña(dni);
                lblMensaje.Text = mensaje;

                if (mensaje == "Correo enviado exitosamente.")
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Visible = true;
                    ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                        "setTimeout(function(){ window.location.href = 'default.aspx'; }, 3000);", true);
                }
                else
                {
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingresa un DNI válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        }



        private void EnviarCorreo(string email, string contraseña)
        {
            try
            {
                var mensaje = new System.Net.Mail.MailMessage();
                mensaje.From = new System.Net.Mail.MailAddress("tu_correo@dominio.com");
                mensaje.To.Add(email);
                mensaje.Subject = "Recuperación de Contraseña";
                mensaje.Body = "Hola, tu contraseña es: " + contraseña;

                var smtp = new System.Net.Mail.SmtpClient("smtp.dominio.com");
                smtp.Credentials = new System.Net.NetworkCredential("tu_usuario", "tu_contraseña");
                smtp.Send(mensaje);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Correo enviado exitosamente.');", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al enviar el correo: {ex.Message}');", true);
            }
        }



    }
}