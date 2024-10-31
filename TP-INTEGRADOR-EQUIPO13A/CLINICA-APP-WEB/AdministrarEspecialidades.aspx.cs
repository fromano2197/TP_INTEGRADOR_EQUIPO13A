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
            //pantalla inicial
            if (!IsPostBack)
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                ListaEspecialidades = negocio.listar();
                repRepeaterEspecialidad.DataSource = ListaEspecialidades;
                repRepeaterEspecialidad.DataBind();


            }

            //modificar


        }

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {       
                int idEspecialidad = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ModificarEspecialidad.aspx?id="+idEspecialidad);


            }
        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idEspecialidad = Convert.ToInt32(e.CommandArgument);
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                negocio.eliminar(idEspecialidad);
                Response.Redirect("AdministrarEspecialidades.aspx", false);

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarEspecialidad.aspx", false);
        }
    }
}