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
    public partial class ModificarEspecialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idProfesional = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                Session.Add("ListaEspecialidadesProfesional", negocio.listarPorProfesional(idProfesional));
                repRepeaterEspecialidad.DataSource = Session["ListaEspecialidadesProfesional"];
                repRepeaterEspecialidad.DataBind();

            }
        }

        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idEspecialidad = Convert.ToInt32(e.CommandArgument);
                int idProfesional = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                Especialidad aux = new Especialidad();
                aux = negocio.listar_porID(idEspecialidad);

                negocio.EliminarRelacionProfesional(aux, idProfesional);
                Response.Redirect("BuscarProfesional.aspx", false);

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            int idProfesional = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
            Response.Redirect("AgregarEspecialidadProfeisonal.aspx?id=" + idProfesional);

        }
    }
}