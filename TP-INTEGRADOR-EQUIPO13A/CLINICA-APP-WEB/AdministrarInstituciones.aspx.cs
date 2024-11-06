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
        public List<Institucion> ListaInstituciones { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InstitucionNegocio negocio = new InstitucionNegocio();
                ListaInstituciones = negocio.listar();
                repRepeaterInstitucion.DataSource = ListaInstituciones;
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
                InstitucionNegocio negocio = new InstitucionNegocio();
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

