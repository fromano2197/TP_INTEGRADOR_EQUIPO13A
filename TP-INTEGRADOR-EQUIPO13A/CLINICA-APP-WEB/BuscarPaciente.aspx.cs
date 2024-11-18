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
        public List<Paciente> ListaPacientes { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PacienteNegocio negocio = new PacienteNegocio();
                Session.Add("listar", negocio.listar());
                repRepeater.DataSource = Session["listar"];
                repRepeater.DataBind();
            }
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Paciente> lista = (List<Paciente>)Session["listar"];
            List<Paciente> listaFiltrada = lista.FindAll(x => x.DatosPersona.Nombre.ToUpper().Contains(txtBuscarPaciente.Text.ToUpper()) || x.DatosPersona.Apellido.ToUpper().Contains(txtBuscarPaciente.Text.ToUpper()) || x.DatosPersona.Dni.ToUpper().Contains( txtBuscarPaciente.Text.ToUpper()));
            repRepeater.DataSource = listaFiltrada;
            repRepeater.DataBind();
        }
        

        protected void btnAgregarProfesional_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPaciente.aspx", false);
        }


       

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
                int idPaciente = Convert.ToInt32(e.CommandArgument);
                Paciente aux = new Paciente();
                List<Paciente> lista= new List<Paciente>();
                lista=negocio.listar_porID(idPaciente);
                aux = lista[0];
                if (aux.activo == true)
                {
                    aux.activo = false;
                }
                else { aux.activo = true; }

                negocio.modificarEstado(aux);
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


    }
}
