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
        public List<Profesional> ListaProfesionales { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfesionalNegocio negocio = new ProfesionalNegocio();
                Session.Add("listarProfesionales", negocio.listarProfesionales());
                repRepeater.DataSource = Session["listarProfesionales"];
                repRepeater.DataBind();
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Profesional> lista = (List<Profesional>)Session["listarProfesionales"];
            List<Profesional> listaFiltrada = lista.FindAll(x => x.Persona.Nombre.ToUpper().Contains(txtBuscarProfesional.Text.ToUpper()) || x.Persona.Apellido.ToUpper().Contains(txtBuscarProfesional.Text.ToUpper()) || x.Especialidades.Any(especialidad=>especialidad.NombreEspecialidad.ToUpper().Contains(txtBuscarProfesional.Text.ToUpper())) || x.Institucion.Any(institucion => institucion.Nombre.ToUpper().Contains(txtBuscarProfesional.Text.ToUpper())) || (txtBuscarProfesional.Text.ToUpper() == "ACTIVO" && x.Estado == true) ||
            (txtBuscarProfesional.Text.ToUpper() == "ELIMINADO" && x.Estado == false)); ;
            repRepeater.DataSource= listaFiltrada;
            repRepeater.DataBind();
        }

        protected void btnVisualizar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Visualizar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetallesProfesionales.aspx?id=" + idPersona);

            }
        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idProfesional = Convert.ToInt32(e.CommandArgument);
                ProfesionalNegocio negocio = new ProfesionalNegocio();
                Profesional aux = new Profesional();
                List<Profesional> lista = new List<Profesional>();
                lista = negocio.listar_porID(idProfesional);
                aux = lista[0];
                if (aux.Estado == true)
                {
                    aux.Estado = false;
                }
                else { aux.Estado = true; }

                negocio.modificarEstado(aux);
                Response.Redirect("BuscarProfesional.aspx", false);

            }
        }

        protected void btnAgregarProfesional_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgragarProfesional.aspx", false);
        }


       

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ModificarProfesional.aspx?id=" + idPersona);

            }
        }
    }
}






