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
    public partial class AgregarEspecialidadProfeisonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAgregarEspecialidad_Click(object sender, EventArgs e)
        {


            int idProfesional = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
            Especialidad aux = new Especialidad();
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            aux.NombreEspecialidad = txtEspecialidad.Text;
            aux.IdEspecialidad = negocio.buscarIDEespecialidad(aux.NombreEspecialidad);



            if (aux.IdEspecialidad <= 0)
            {
                lblMensaje.Text = "La especialidad indicada no está registrada.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return;
            }
            negocio.AgregarEspecialidadProfesional(idProfesional, aux.IdEspecialidad);

            lblMensaje.Text = "Especialidad agregada correctamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;
            lblMensaje.Visible = true;
            Response.Redirect("BuscarProfesional.aspx", false);


        }
    }
}