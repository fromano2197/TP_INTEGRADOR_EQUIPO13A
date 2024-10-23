using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace CLINICA_APP_WEB
{
    public partial class BuscarProfesional : System.Web.UI.Page
    {
        private void LimpiarCampos()
        {
            lblNombre1.Text = string.Empty;
            lblApellido1.Text = string.Empty;
            lblDni1.Text = string.Empty;
            lblMensaje.Text = string.Empty;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            int dni;
            if (int.TryParse(txtDni.Text, out dni))
            {
                PacienteNegocio negocio = new PacienteNegocio();
                Persona paciente = negocio.listar(dni);
                LimpiarCampos();
                if (paciente != null)
                {


                    lblNombre1.Text = paciente.Nombre;
                    lblApellido1.Text = paciente.Apellido;
                    lblDni1.Text = paciente.Dni.ToString();
                }
                else
                {

                    lblMensaje.Text = "Paciente no encontrado.";
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un DNI válido.";
            }

        }

    }
}
