using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace CLINICA_APP_WEB
{
    public partial class AdministrarEspecialidades : System.Web.UI.Page
    {
        public List<Especialidad> ListaEspecialidades { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                Session.Add("ListaEspecialidades", negocio.listar());
                repRepeaterEspecialidad.DataSource = Session["ListaEspecialidades"];
                repRepeaterEspecialidad.DataBind();


            }

        }

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {       
                int idEspecialidad = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ModificarEspecialidad.aspx?id="+idEspecialidad);


            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Especialidad> lista = (List<Especialidad>)Session["ListaEspecialidades"];
            List<Especialidad> listaFiltrada = lista.FindAll(x => x.NombreEspecialidad.ToUpper().Contains(txtBuscarEspecialidad.Text.ToUpper()));
            repRepeaterEspecialidad.DataSource = listaFiltrada;
            repRepeaterEspecialidad.DataBind();
        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idEspecialidad = Convert.ToInt32(e.CommandArgument);
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                Especialidad aux = new Especialidad();
                aux = negocio.listar_porID(idEspecialidad);
                if(aux.Activo == true)
                {
                    aux.Activo = false;
                }
                else { aux.Activo= true; }

                negocio.cambiarEstado(aux);
                Response.Redirect("AdministrarEspecialidades.aspx", false);

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEspecialidad.aspx", false);
        }
    }
}