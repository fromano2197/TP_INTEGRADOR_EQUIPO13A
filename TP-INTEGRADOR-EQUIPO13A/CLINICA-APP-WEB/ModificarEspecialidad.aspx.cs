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
    public partial class ModificarEspecialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {

            EspecialidadNegocio negocio = new EspecialidadNegocio();

            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                if (id > 0)
                {
                    Especialidad seleccionado = new Especialidad();
                    List<Especialidad> lista = negocio.listar_porID(id);
                    seleccionado = lista[0];
                    txtIDEspecialidad.Text = seleccionado.IdEspecialidad.ToString();
                    txtEspecialidad.Text = seleccionado.NombreEspecialidad.ToString();
                }
            }
        }

        protected void btnModificarEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidad seleccionado = new Especialidad();
            EspecialidadNegocio negocio = new EspecialidadNegocio();
            seleccionado.IdEspecialidad = int.Parse(Request.QueryString["id"].ToString());
            seleccionado.NombreEspecialidad = txtEspecialidad.Text;
            negocio.Modificar(seleccionado);
            Response.Redirect("AdministrarEspecialidades.aspx", false);
        }
    }
}