using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si estamos en una página de login
            string currentPage = Request.Url.AbsolutePath.ToLower();

            // Si estamos en LoginPacientes.aspx o LoginMedicos.aspx, ocultamos el navbar
            if (currentPage.Contains("loginpacientes.aspx") || currentPage.Contains("loginmedicos.aspx"))
            {
                pacienteNavbar.Visible = false;
                medicoNavbar.Visible = false;
            }
            else
            {
                // Verificar si existe el tipo de usuario en la sesión
                if (Session["TipoUsuario"] != null)
                {
                    string tipoUsuario = Session["TipoUsuario"].ToString();

                    // Mostrar el navbar correspondiente según el tipo de usuario
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
                }
                else
                {
                    // Si no hay sesión de usuario, ocultamos ambos navbars
                    pacienteNavbar.Visible = false;
                    medicoNavbar.Visible = false;
                }
            }
        }
    }

}