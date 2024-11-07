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
    public partial class BuscarPaciente : System.Web.UI.Page
    {
        public List<Persona> ListaPacientes { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PacienteNegocio negocio = new PacienteNegocio();
                ListaPacientes = negocio.listar();
                repRepeater.DataSource = ListaPacientes;
                repRepeater.DataBind();
            }
        }
        //protected void btnVisualizar_Command(object sender, CommandEventArgs e)
        //{
        //    if (e.CommandName == "Visualizar")
        //    {
        //        int idPersona = Convert.ToInt32(e.CommandArgument);
        //        Response.Redirect("DetallesProfesionales.aspx?id=" + idPersona);

        //    }
        //}
        //protected void btnEliminar_Command(object sender, CommandEventArgs e)
        //{
        //    if (e.CommandName == "Eliminar")
        //    {
        //        int idPersona = Convert.ToInt32(e.CommandArgument);
        //        EliminarLogicoProfesional(idPersona);
        //    }
        //}

        protected void btnAgregarProfesional_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx", false);
        }


        //private void EliminarLogicoProfesional(int idPersona)
        //{
        //    try
        //    {
        //        AccesoDatos accesoDatos = new AccesoDatos();
        //        string storedProcedure = "SP_BAJA_LOGICA_PROFESIONAL";

        //        accesoDatos.setearProcedimiento(storedProcedure);
        //        accesoDatos.setearParametro("@IDPERSONA", idPersona);

        //        accesoDatos.ejecutarAccion();

        //        ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
        //        List<Profesional> listaProfesionales = profesionalNegocio.listarProfesionales();

        //        repRepeater.DataSource = listaProfesionales;
        //        repRepeater.DataBind();

        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "alert('El profesional ha sido dado de baja.');", true);
        //    }
        //    catch (Exception ex)
        //    {

        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "mensajeError", $"alert('Error al dar de baja al profesional: {ex.Message}');", true);
        //    }
        //}

        protected void btnModificar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Modificar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ModificarPaciente.aspx?id=" + idPersona);

            }
        }

        protected void btnEliminar_Command1(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                PacienteNegocio negocio = new PacienteNegocio();
                int idPersona = Convert.ToInt32(e.CommandArgument);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "mensaje", "alert('El paciente ha sido dado de baja.');", true);
                negocio.eliminarPaciente(idPersona);
                Response.Redirect("BuscarPaciente.aspx", false);

            }
        }

        protected void btnVisualizar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Visualizar")
            {
                int idPersona = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetallesPacientes.aspx?id=" + idPersona);

            }
        }

        /*protected void VerDetalle_Click(object sender, EventArgs e)
        {


            LinkButton btn = (LinkButton)sender;
            string articuloId = btn.CommandArgument;


            Response.Redirect("Detalle.aspx");
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            int dni;
            if (int.TryParse(txtDni.Text, out dni))
            {
                PacienteNegocio negocio = new PacienteNegocio();
                Persona paciente = negocio.listar(dni);
                
                if (paciente != null)
                {

                    
                    lblNombre.Text = paciente.Nombre;
                    lblApellido.Text = paciente.Apellido;
                    lblDni.Text = paciente.Dni.ToString();
                }
                else
                {
                    
                    lblMensaje.Text = "Paciente no encontrado.";
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un DNI válido.";
            }

        }*/

    }
}
