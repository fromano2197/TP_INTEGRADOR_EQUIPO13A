using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace CLINICA_APP_WEB
{
    public partial class turnosDia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
            int id = Session["idProfesional"] != null ? int.Parse(Session["idProfesional"].ToString()) : 0;
            TurnoNegocio negocio = new TurnoNegocio();
            Session.Add("listarTurnos", negocio.listarPorProfesional(id));
            repRepeater.DataSource = Session["listarTurnos"];
            repRepeater.DataBind();
            }
        }

        protected void btnObservaciones_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Observaciones")
            {
                int idTurno = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("RegistrarConsulta.aspx?id=" + idTurno);
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