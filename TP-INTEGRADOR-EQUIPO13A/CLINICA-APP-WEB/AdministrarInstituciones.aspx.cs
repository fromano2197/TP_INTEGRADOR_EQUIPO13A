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
                Session.Add("listarInstituciones", negocio.listar());
                repRepeaterInstitucion.DataSource = Session["listarInstituciones"];
                repRepeaterInstitucion.DataBind();
            }
        }
        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Institucion> lista = (List<Institucion>)Session["listarInstituciones"];
            List<Institucion> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscarInstitucion.Text.ToUpper()) || (txtBuscarInstitucion.Text.ToUpper() == "ACTIVO" && x.Activo == true) ||
            (txtBuscarInstitucion.Text.ToUpper() == "ELIMINADO" && x.Activo == false));
            repRepeaterInstitucion.DataSource = listaFiltrada;
            repRepeaterInstitucion.DataBind();
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
                Institucion aux = new Institucion();
                aux=negocio.listar_porID(idInstitucion);

                if (aux.Activo == true)
                {
                    aux.Activo = false;
                }
                else { aux.Activo = true; }

                negocio.cambiarEstado(aux);
                Response.Redirect("AdministrarInstituciones.aspx", false);

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarInstitucion.aspx", false);
        }
    }
}

