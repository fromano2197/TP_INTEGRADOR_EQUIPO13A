using System;
using System.Web;
using System.Web.UI;

namespace CLINICA_APP_WEB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tipoUsuario = Session["TipoUsuario"] as string;

                if (tipoUsuario != null)
                {
    
                    switch (tipoUsuario)
                    {
                        case "paciente":
                            pacienteNavbar.Visible = true;
                            medicoNavbar.Visible = false;
                            break;
                        case "profesional":
                            pacienteNavbar.Visible = false;
                            medicoNavbar.Visible = true;
                            break;
                        case "administrador":
                            pacienteNavbar.Visible = false;
                            medicoNavbar.Visible = false;
                            adminNavbar.Visible = true;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        protected void RedirigirPortalPaciente(object sender, EventArgs e)
        {
            if (Session["idPaciente"] != null)
            {
                int idPaciente = (int)Session["idPaciente"];
                Response.Redirect($"PortalPacientes.aspx?idPaciente={idPaciente}", false);
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void RedirigirPortalProfesional(object sender, EventArgs e)
        {
            if (Session["idProfesional"] != null)
            {
                int idProfesional = (int)Session["idProfesional"];
                Response.Redirect($"PortalMedicos.aspx?idProfesional={idProfesional}", false);
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void RedirigirAdministrador(object sender, EventArgs e)
        {
            if (Session["TipoUsuario"] != null && (string)Session["TipoUsuario"] == "administrador")
            {
                Response.Redirect("Administrador.aspx", false);
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Default.aspx", false);
        }

       
    }
}

