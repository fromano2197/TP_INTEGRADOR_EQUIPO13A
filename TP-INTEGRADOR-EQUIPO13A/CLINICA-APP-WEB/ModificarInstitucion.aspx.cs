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
    public partial class ModificarInstitucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            InstitucionNegocio negocio = new InstitucionNegocio();

            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                if (id > 0)
                {
                    Institucion seleccionado = new Institucion();
                    List<Institucion> lista = negocio.listar_porID(id);
                    seleccionado = lista[0];
                    txtIDInstitucion.Text = seleccionado.IdInstitucion.ToString();
                    txtNombreInstitucion.Text = seleccionado.Nombre.ToString();
                    txtDireccionInstitucion.Text = seleccionado.Direccion.ToString();
                    txtFechaInstitucion.Text = seleccionado.Fecha_Apertura.ToString();
                }
            }
        }

        protected void btnModificarInstitucion_Click(object sender, EventArgs e)
        {
            Institucion seleccionado = new Institucion();
            InstitucionNegocio negocio = new InstitucionNegocio();
            seleccionado.IdInstitucion = int.Parse(Request.QueryString["id"].ToString());
            seleccionado.Nombre = txtNombreInstitucion.Text;
            seleccionado.Direccion = txtDireccionInstitucion.Text;
            seleccionado.Fecha_Apertura = DateTime.Parse(txtFechaInstitucion.Text);
            negocio.Modificar(seleccionado);
            Response.Redirect("AdministrarInstituciones.aspx", false);
        }
    }
}
        
    
