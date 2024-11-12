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
    public partial class BuscarPaciente : System.Web.UI.Page
    {
        public List<Persona> ListaPacientes { get; set; }


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
            List<Persona> lista = (List<Persona>)Session["listar"];
            List<Persona> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscarPaciente.Text.ToUpper()) || x.Apellido.ToUpper().Contains(txtBuscarPaciente.Text.ToUpper()) || x.Dni.ToUpper().Contains( txtBuscarPaciente.Text.ToUpper()));
            repRepeater.DataSource = listaFiltrada;
            repRepeater.DataBind();
        }
        

        protected void btnAgregarProfesional_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx", false);
        }


       

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ModificarPaciente.aspx?id=" + idPersona);

            }
        }

        protected void btnEliminar_Command1(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                PacienteNegocio negocio = new PacienteNegocio();
                int idPersona = Convert.ToInt32(e.CommandArgument);
                negocio.eliminarPaciente(idPersona);
                Response.Redirect("BuscarPaciente.aspx", false);

            }
        }

        protected void btnVisualizar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Visualizar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetallesPacientes.aspx?id=" + idPersona);

            }
        }


    }
}
