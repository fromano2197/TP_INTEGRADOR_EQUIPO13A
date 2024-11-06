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
using Dominio;

namespace CLINICA_APP_WEB
{
    public partial class DetallesProfesionales : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ProfesionalNegocio negocio = new ProfesionalNegocio();

            if (!IsPostBack)
            {

                int id = 0;
                if (int.TryParse(Request.QueryString["id"], out id) && id > 0)
                {
                    List<Profesional> lista = negocio.listar_porID(id);
                    if (lista.Count > 0)
                    {
                        Profesional seleccionado = lista[0];

                        txtDni.Text = seleccionado.Persona.Dni.ToString();
                        txtNombre.Text = seleccionado.Persona.Nombre;
                        txtApellido.Text = seleccionado.Persona.Apellido;
                        txtFechaNac.Text = seleccionado.Persona.FechaNacimiento.ToString("dd/MM/yyyy");
                        txtEmail.Text = seleccionado.Persona.ContactoCliente.Email;
                        txtTelefono.Text = seleccionado.Persona.ContactoCliente.telefono.ToString();
                        txtDireccion.Text = seleccionado.Persona.ContactoCliente.Direccion;
                        txtUsuario.Text = seleccionado.Usuario.User;


                        lblEspecialidades.Text = string.Join(", ", seleccionado.Especialidades.Select(especialidad => especialidad.NombreEspecialidad));


                    }
                    else
                    {
                        lblMensaje.Text = "No se encontró el profesional con el ID proporcionado.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Visible = true;
                    }
                }
                else
                {
                    lblMensaje.Text = "ID de profesional no válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                }
            }
        }




        private void CargarDetallesProfesional(int idPersona)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            accesoDatos.setConsulta(@"
        SELECT
            p.DNI,
            p.NOMBRE,
            p.APELLIDO,
            p.FECHA_NACIMIENTO,
            c.EMAIL,
            c.TELEFONO,
            c.DIRECCION,
            u.NOMBRE_USUARIO AS Usuario,
            STRING_AGG(e.ESPECIALIDAD, ', ') AS Especialidades
        FROM
            PROFESIONAL pr
        INNER JOIN PERSONA p ON pr.IDPERSONA = p.IDPERSONA
        INNER JOIN CONTACTO c ON p.IDPERSONA = c.IDPERSONA
        INNER JOIN USUARIO u ON pr.IDUSUARIO = u.IDUSUARIO
        LEFT JOIN PROFESIONAL_POR_ESPECIALIDAD ppe ON pr.IDPROFESIONAL = ppe.IDPROFESIONAL
        LEFT JOIN ESPECIALIDAD e ON ppe.IDESPECIALIDAD = e.IDESPECIALIDAD
        WHERE
            p.IDPERSONA = @IDPERSONA
        GROUP BY
            p.DNI,
            p.NOMBRE,
            p.APELLIDO,
            p.FECHA_NACIMIENTO,
            c.EMAIL,
            c.TELEFONO,
            c.DIRECCION,
            u.NOMBRE_USUARIO;");

            accesoDatos.setearParametro("@IDPERSONA", idPersona);

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