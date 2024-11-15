using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class PortalMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Session["idProfesional"] != null ? int.Parse(Session["idProfesional"].ToString()) : 0;
            }
            
        }

        protected void btnMisPacientes_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Pacientes")
            {
                int id = Session["idProfesional"] != null ? int.Parse(Session["idProfesional"].ToString()) : 0;
                Response.Redirect("misPacientes.aspx?id=" + id);
            }
        }

        protected void btnTurnos_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Turnos")
            {
                int id = Session["idProfesional"] != null ? int.Parse(Session["idProfesional"].ToString()) : 0;
                Response.Redirect("turnosDia.aspx?id=" + id);
            }
        }

        protected void btnRegistrarConsulta_Command(object sender, CommandEventArgs e)
        {

        }
    }
}