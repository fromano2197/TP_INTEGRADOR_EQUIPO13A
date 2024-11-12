using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace CLINICA_APP_WEB
{
    public partial class BuscarProfesional : System.Web.UI.Page
    {
        public List<Profesional> ListaProfesionales { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProfesionalNegocio negocio = new ProfesionalNegocio();
                Session.Add("listarProfesionales", negocio.listarProfesionales());
                repRepeater.DataSource = Session["listarProfesionales"];
                repRepeater.DataBind();
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Profesional> lista = (List<Profesional>)Session["listarProfesionales"];
            List<Profesional> listaFiltrada = lista.FindAll(x => x.Persona.Nombre.ToUpper().Contains(txtBuscarProfesional.Text.ToUpper()) || x.Persona.Apellido.ToUpper().Contains(txtBuscarProfesional.Text.ToUpper()) || x.Especialidades.Any(especialidad=>especialidad.NombreEspecialidad.ToUpper().Contains(txtBuscarProfesional.Text.ToUpper())) || x.Institucion.Nombre.ToUpper().Contains(txtBuscarProfesional.Text.ToUpper()));
            repRepeater.DataSource= listaFiltrada;
            repRepeater.DataBind();
        }

        protected void btnVisualizar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Visualizar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetallesProfesionales.aspx?id=" + idPersona);

            }
        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                EliminarLogicoProfesional(idPersona);
            }
        }

        protected void btnAgregarProfesional_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgragarProfesional.aspx", false);
        }


        private void EliminarLogicoProfesional(int idPersona)
        {
            try
            {
                AccesoDatos accesoDatos = new AccesoDatos();
                string storedProcedure = "SP_BAJA_LOGICA_PROFESIONAL";

                accesoDatos.setearProcedimiento(storedProcedure);
                accesoDatos.setearParametro("@IDPROFESIONAL", idPersona);

                accesoDatos.ejecutarAccion();

                ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
                List<Profesional> listaProfesionales = profesionalNegocio.listarProfesionales();

                repRepeater.DataSource = listaProfesionales;
                repRepeater.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "alert('El profesional ha sido dado de baja.');", true);
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeError", $"alert('Error al dar de baja al profesional: {ex.Message}');", true);
            }
        }

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ModificarProfesional.aspx?id=" + idPersona);

            }
        }
    }
}






