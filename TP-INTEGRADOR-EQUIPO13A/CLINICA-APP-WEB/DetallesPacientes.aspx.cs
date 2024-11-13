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
    public partial class DetallesPacientes : System.Web.UI.Page
    {
  

            protected void Page_Load(object sender, EventArgs e)
            {
                PacienteNegocio negocio = new PacienteNegocio();

                if (!IsPostBack)
                {

                    int id = 0;
                    if (int.TryParse(Request.QueryString["id"], out id) && id > 0)
                    {
                        List<Paciente> lista = negocio.listar_porID(id);
                        if (lista.Count > 0)
                        {
                            Paciente seleccionado = lista[0];
                            txtDni.Text = seleccionado.DatosPersona.Dni.ToString();
                            txtNombre.Text = seleccionado.DatosPersona.Nombre;
                            txtApellido.Text = seleccionado.DatosPersona.Apellido;
                            txtFechaNac.Text = seleccionado.DatosPersona.FechaNacimiento.ToString("dd/MM/yyyy");
                            txtEmail.Text = seleccionado.DatosPersona.ContactoCliente.Email;
                            txtTelefono.Text = seleccionado.DatosPersona.ContactoCliente.telefono.ToString();
                            txtDireccion.Text = seleccionado.DatosPersona.ContactoCliente.Direccion;

                        }
                        else
                        {
                            lblMensaje.Text = "No se encontró el paciente con el ID proporcionado.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                            lblMensaje.Visible = true;
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "ID de paciente no válido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Visible = true;
                    }
                }
            }
        }
    }
