using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class LoginPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["TipoUsuario"] = "Paciente";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("PortalPacientes.aspx", false);
        }
    }
}