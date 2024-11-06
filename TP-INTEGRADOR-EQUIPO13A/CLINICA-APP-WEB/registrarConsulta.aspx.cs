using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class registrarConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void txtDni_TextChanged(object sender, EventArgs e)
        {
            int DNI = int.Parse(txtDni.Text);
            PacienteNegocio negocio = new PacienteNegocio();
            Persona seleccionado = new Persona();
            seleccionado = negocio.listar(DNI);

            txtApellidoPaciente.Text = seleccionado.Apellido;
            txtNombrePaciente.Text = seleccionado.Nombre;
        }

        protected void btnRegistrarConsulta_Click(object sender, EventArgs e)
        {
            int DNI = int.Parse(txtDni.Text);
            PacienteNegocio negocio = new PacienteNegocio();
            Paciente aux = new Paciente();
           
            int IDPACIENTE = negocio.buscarIDPaciente(DNI);

        }
    }
}