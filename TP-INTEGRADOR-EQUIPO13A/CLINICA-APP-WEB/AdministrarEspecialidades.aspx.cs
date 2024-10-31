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
    public partial class AdministrarEspecialidades : System.Web.UI.Page
    {
        public List<Especialidad> ListaEspecialidades { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                ListaEspecialidades = negocio.listar();
                repRepeaterEspecialidad.DataSource = ListaEspecialidades;
                repRepeaterEspecialidad.DataBind();
            }
        }
    }
}