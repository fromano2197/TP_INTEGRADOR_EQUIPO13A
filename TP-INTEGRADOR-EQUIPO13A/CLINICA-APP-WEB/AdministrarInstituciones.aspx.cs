using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class AdministrarInstituciones : System.Web.UI.Page
    {
        public List<Institucion> ListaEspecialidades { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InstitucionNegocio negocio = new InstitucionNegocio();
                ListaEspecialidades = negocio.listar();
                repRepeaterInstitucion.DataSource = ListaEspecialidades;
                repRepeaterInstitucion.DataBind();
            }
        }
        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idInstitucion = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ModificarInstitucion.aspx?id=" + idInstitucion);


            }
        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idInstitucion = Convert.ToInt32(e.CommandArgument);
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                negocio.eliminar(idInstitucion);
                Response.Redirect("AdministrarInstituciones.aspx", false);

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarInstitucion.aspx", false);
        }
    }
}

