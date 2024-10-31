using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CLINICA_APP_WEB
{
    public partial class AgregarEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            //agregar
            Especialidad aux = new Especialidad();
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            aux.NombreEspecialidad = txtEspecialidad.Text;
            negocio.Agregar(aux);
            Response.Redirect("AdministrarEspecialidades.aspx", false);
            
            
        }
    }
}