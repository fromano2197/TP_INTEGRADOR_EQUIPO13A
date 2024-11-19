using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class EstudiosDePacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PacienteNegocio negocio = new PacienteNegocio();
                Session.Add("listar", negocio.listar());
                repRepeater.DataSource = Session["listar"];
                repRepeater.DataBind();
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Paciente> lista = (List<Paciente>)Session["listar"];
            List<Paciente> listaFiltrada = lista.FindAll(x => x.DatosPersona.Nombre.ToUpper().Contains(txtBuscarPaciente.Text.ToUpper()) || x.DatosPersona.Apellido.ToUpper().Contains(txtBuscarPaciente.Text.ToUpper()) || x.DatosPersona.Dni.ToUpper().Contains(txtBuscarPaciente.Text.ToUpper()));
            repRepeater.DataSource = listaFiltrada;
            repRepeater.DataBind();
        }

        protected void btnCargarEstudios_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "CargarEstudios")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("CargarEstrudios.aspx?id=" + idPersona);

            }
        }
      

    }
}