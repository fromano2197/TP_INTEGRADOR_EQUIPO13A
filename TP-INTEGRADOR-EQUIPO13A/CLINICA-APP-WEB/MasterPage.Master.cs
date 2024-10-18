using System;
using System.Web;
using System.Web.UI;

namespace CLINICA_APP_WEB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPage = Request.Url.AbsolutePath.ToLower();

           
            if (currentPage.Contains("loginpacientes.aspx") || currentPage.Contains("loginmedicos.aspx"))
            {
                pacienteNavbar.Visible = false;
                medicoNavbar.Visible = false;
                btnCerrarSesion.Visible = false; 
            }
            else
            {
                if (Session["TipoUsuario"] != null)
                {
                    string tipoUsuario = Session["TipoUsuario"].ToString();

                    if (tipoUsuario == "Paciente")
                    {
                        pacienteNavbar.Visible = true;
                        medicoNavbar.Visible = false;
                    }
                    else if (tipoUsuario == "Medico")
                    {
                        medicoNavbar.Visible = true;
                        pacienteNavbar.Visible = false;
                    }

                  
                    btnCerrarSesion.Visible = true;
                }
                else
                {
                   
                    pacienteNavbar.Visible = false;
                    medicoNavbar.Visible = false;
                    btnCerrarSesion.Visible = false;
                }
            }
        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            
            Session.Abandon();  

            
            Response.Redirect("Default.aspx",false);
        }
    }
}
