using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace CLINICA_APP_WEB
{
    public partial class DetallesProfesionales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idProfesional = Convert.ToInt32(Request.QueryString["IDPROFESIONAL"]);
                CargarDetallesProfesional(idProfesional);
            }
        }

        private void CargarDetallesProfesional(int idProfesional)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            accesoDatos.setearProcedimiento("SP_VER_DETALLES_PROFESIONAL");
            accesoDatos.setearParametro("@IDPROFESIONAL", idProfesional);

            try
            {
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read()) 
                {
                    txtDni.Text = accesoDatos.Lector["DNI"].ToString();
                    txtNombre.Text = accesoDatos.Lector["Nombre"].ToString();
                    txtApellido.Text = accesoDatos.Lector["Apellido"].ToString();
                    txtFechaNac.Text = Convert.ToDateTime(accesoDatos.Lector["FechaNacimiento"]).ToString("dd/MM/yyyy");
                    txtEmail.Text = accesoDatos.Lector["Email"].ToString();
                    txtTelefono.Text = accesoDatos.Lector["Telefono"].ToString();
                    txtDireccion.Text = accesoDatos.Lector["Direccion"].ToString();
                    txtUsuario.Text = accesoDatos.Lector["Usuario"].ToString();
                    lblEspecialidades.Text = accesoDatos.Lector["Especialidades"].ToString();
                }
                else
                {
                    lblMensaje.Text = "No se encontraron detalles para este profesional.";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los detalles: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}