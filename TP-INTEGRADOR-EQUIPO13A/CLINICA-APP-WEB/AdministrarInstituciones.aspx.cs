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
    public partial class AdministrarInstituciones : System.Web.UI.Page
    {
        public List<Institucion> ListaEspecialidades { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InstitucionNegocio negocio = new InstitucionNegocio();
                ListaEspecialidades = negocio.listar();
                repRepeaterInstitucion.DataSource = ListaEspecialidades;
                repRepeaterInstitucion.DataBind();
            }
        }
    }
}