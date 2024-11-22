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
    public partial class ModificarInstituciones : System.Web.UI.Page
    {
        public List<Institucion> ListaInstituciones { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idProfesional = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
                InstitucionNegocio negocio = new InstitucionNegocio();
                Session.Add("listarInstitucionesProfesionales", negocio.ObtenerInstitucionesPorProfesional(idProfesional));
                repRepeaterInstitucion.DataSource = Session["listarInstitucionesProfesionales"];
                repRepeaterInstitucion.DataBind();
            }
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idInstitucion = Convert.ToInt32(e.CommandArgument);
                int idProfesional = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
                InstitucionNegocio negocio = new InstitucionNegocio();
                Institucion aux = new Institucion();
                aux = negocio.listar_porID(idInstitucion);

                negocio.EliminarRelacionProfesional(aux, idProfesional);
                Response.Redirect("BuscarProfesional.aspx", false);

            }
        }

            protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int idProfesional = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
            Response.Redirect("AgregarInstitucionProfesional.aspx?id=" + idProfesional);
        }
    }
}