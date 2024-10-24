﻿using System;
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
                        case "Paciente":
                            pacienteNavbar.Visible = true;
                            medicoNavbar.Visible = false;
                            break;
                        case "Medico":
                            pacienteNavbar.Visible = false;
                            medicoNavbar.Visible = true;
                            break;
                        case "Admin":
                            pacienteNavbar.Visible = false;
                            medicoNavbar.Visible = false;
                            break;
                        default:
                   
                            break;
                    }
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
