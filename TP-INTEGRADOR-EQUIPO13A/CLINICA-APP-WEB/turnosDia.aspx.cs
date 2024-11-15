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
            int id = int.Parse(Session["idProfesional"].ToString());
            TurnoNegocio negocio = new TurnoNegocio();
            Session.Add("listarTurnos", negocio.listarPorProfesional(id));
            repRepeater.DataSource = Session["listarTurnos"];
            repRepeater.DataBind();
        }
    }
}