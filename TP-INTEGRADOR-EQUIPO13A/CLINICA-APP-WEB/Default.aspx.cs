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
                string consulta = @"SELECT id_usuarios, tipo_usuario,
            ISNULL(id_paciente, 0) AS id_paciente,
            ISNULL(id_profesional, 0) AS id_profesional,
            ISNULL(id_administrador, 0) AS id_administrador
            FROM usuarios
            WHERE usuario = @USUARIO AND contraseña = @CONTRASEÑA";


                Datos.setearParametro("@USUARIO", usuario);
                Datos.setearParametro("@CONTRASEÑA", contraseña);
                Datos.setConsulta(consulta);

                Datos.ejecutarLectura();

                if (Datos.Lector.Read())
                {
                    int idUsuario = (int)Datos.Lector["id_usuarios"];
                    int idPaciente = (int)Datos.Lector["id_paciente"];
                    int idProfesional = (int)Datos.Lector["id_profesional"];
                    int idAdministrador = (int)Datos.Lector["id_administrador"];
                    string tipoUsuario = (string)Datos.Lector["tipo_usuario"];

                    Session["idPaciente"] = idPaciente;
                    Session["TipoUsuario"] = tipoUsuario;



                    switch (tipoUsuario)
                    {
                        case "paciente":
                            Response.Redirect("PortalPacientes.aspx", false);
                            break;
                        case "profesional":
                            Response.Redirect("PortalMedicos.aspx", false);
                            break;
                        case "administrador":
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