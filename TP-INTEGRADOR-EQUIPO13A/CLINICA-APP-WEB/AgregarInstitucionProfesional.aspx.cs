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
    public partial class AgregarInstitucionProfesional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAgregarInstitucion_Click(object sender, EventArgs e)
        {
            int idProfesional = Request.QueryString["id"] != null ? int.Parse(Request.QueryString["id"]) : 0;
            Institucion aux = new Institucion();
            InstitucionNegocio negocio = new InstitucionNegocio();
            aux.Nombre = txtNombreInstitucion.Text;
            aux.IdInstitucion = negocio.buscarIDInstitucion(aux.Nombre);



            if (aux.IdInstitucion <= 0)
            {
                lblMensaje.Text = "La institucion indicada no está registrada.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                return;
            }
            negocio.AgregarInstitucionProfesional(idProfesional, aux.IdInstitucion);

            lblMensaje.Text = "Institucion agregada correctamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;
            lblMensaje.Visible = true;
            Response.Redirect("BuscarProfesional.aspx", false);


        }
    }
}