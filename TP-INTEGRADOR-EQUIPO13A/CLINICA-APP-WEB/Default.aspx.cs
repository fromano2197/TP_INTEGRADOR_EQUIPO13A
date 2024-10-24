using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtPass.Text;

            AccesoDatos Datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT IDUSUARIO, TIPOUSUARIO FROM USUARIO WHERE NOMBRE_USUARIO = @usuario AND CONTRASENA = @contraseña";
                Datos.setConsulta(consulta);
                Datos.setearParametro("@usuario", usuario);
                Datos.setearParametro("@contraseña", contraseña);

                Datos.ejecutarLectura();

                if (Datos.Lector.Read())
                {
                    int idUsuario = (int)Datos.Lector["IDUSUARIO"];
                    string tipoUsuario = (string)Datos.Lector["TIPOUSUARIO"];

                    Session["TipoUsuario"] = tipoUsuario;



                    switch (tipoUsuario)
                    {
                        case "Paciente":
                            Response.Redirect("PortalPacientes.aspx", false);
                            break;
                        case "Medico":
                            Response.Redirect("PortalMedicos.aspx", false);
                            break;
                        case "Admin":
                            Response.Redirect("Administrador.aspx", false);
                            break;
                        default:
                            lblMensaje.Text = "Tipo de usuario no reconocido.";
                            lblMensaje.Visible = true;
                            break;
                    }
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al iniciar sesión: " + ex.Message;
                lblMensaje.Visible = true;
            }
            finally
            {
                Datos.cerrarConexion();
            }
        }

    }
}