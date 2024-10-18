using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class TurnosPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnConsultarTurnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("TomarTurno.aspx",false);
        }
    }
}