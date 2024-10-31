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
    public partial class AgregarInstitucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAgregarInstitucion_Click(object sender, EventArgs e)
        {
            Institucion aux = new Institucion();
            InstitucionNegocio negocio = new InstitucionNegocio();

            aux.Nombre = txtNombreInstitucion.Text;
            aux.Direccion = txtDireccionInstitucion.Text;
            aux.Fecha_Apertura = DateTime.Parse(txtFechaInstitucion.Text);

            negocio.Agregar(aux);
            Response.Redirect("AdministrarInstituciones", false);
        }
    }
}