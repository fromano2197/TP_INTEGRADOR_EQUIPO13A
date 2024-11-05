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
                ListaProfesionales = negocio.listarProfesionales();
                repRepeater.DataSource = ListaProfesionales;
                repRepeater.DataBind();
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

