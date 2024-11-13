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
    public partial class PortalPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoUsuario"]?.ToString() == "paciente" && Session["idPaciente"] != null)
                {
                    btnMisDatosPersonales.CommandArgument = Session["idPaciente"].ToString();
                }

            }
        }

        protected void btnVisualizar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Visualizar")
            {
                if (int.TryParse(e.CommandArgument.ToString(), out int idPersona))
                {
                    Response.Redirect("MisDatos.aspx?id=" + idPersona);
                }
                else
                {
                    // Manejo de errores: el CommandArgument no es un número válido
                    // Puedes mostrar un mensaje o registrar el error según corresponda
                    Response.Write("Error: El ID no es un número válido.");
                }
            }
        }
    }
}