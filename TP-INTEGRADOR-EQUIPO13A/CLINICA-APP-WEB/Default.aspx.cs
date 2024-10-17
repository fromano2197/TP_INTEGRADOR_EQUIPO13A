using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TipoUsuario"] == null)
            {
                if (Request.Url.AbsolutePath.Contains("LoginPacientes.aspx"))
                {
                    Session["TipoUsuario"] = "Paciente";
                }
                else if (Request.Url.AbsolutePath.Contains("LoginMedicos.aspx"))
                {
                    Session["TipoUsuario"] = "Medico";
                }
  
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

    }
}