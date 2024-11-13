using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idadministrador"] != null)
            {
                //btnMisDatosPersonales.CommandArgument = Session["idpaciente"].ToString();
            }
            else
            {
                // Maneja el caso en el que el ID no está disponible, como redirigir o mostrar un mensaje.
            }

        }
    }
}