using Negocio;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class registrarConsulta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                if (int.TryParse(Request.QueryString["id"], out id) && id > 0) { 
                TurnoNegocio negocio = new TurnoNegocio();

                Turno seleccionado = new Turno();

                seleccionado = negocio.listar(id);
                txtDni.Text = seleccionado.Paciente.DatosPersona.Dni;
                txtApellidoPaciente.Text = seleccionado.Paciente.DatosPersona.Apellido;
                txtNombrePaciente.Text = seleccionado.Paciente.DatosPersona.Nombre;
                    

            }
            }
        }


        protected void btnRegistrarConsulta_Click(object sender, EventArgs e)
        {
            TurnoNegocio negocio = new TurnoNegocio();
            Turno aux = new Turno();
            int id = 0;
            if (int.TryParse(Request.QueryString["id"], out id) && id > 0)
            {
                aux.IdTurno = id;
                aux.Observaciones = TxtAreaObservacionesConsulta.Value;
                negocio.RegistrarObservacion(aux);

             }
            Response.Redirect("turnosDia.aspx", false);

        }
    }
}