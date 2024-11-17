using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class misPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Session["idProfesional"] != null ? int.Parse(Session["idProfesional"].ToString()) : 0;
                PacienteNegocio negocio = new PacienteNegocio();
                Session.Add("listarPacientes", negocio.listarPorProfesional(id));
                repRepeater.DataSource = Session["listarPacientes"];
                repRepeater.DataBind();
            }
        }

        protected void btnDetalles_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Detalles")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetallesPacientes.aspx?id=" + id);
            }

        }
    }
}