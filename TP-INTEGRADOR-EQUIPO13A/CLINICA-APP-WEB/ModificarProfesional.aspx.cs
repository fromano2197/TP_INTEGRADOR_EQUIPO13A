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
    public partial class ModificarProfesional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idPersona;
                if (int.TryParse(Request.QueryString["id"], out idPersona) && idPersona > 0)
                {
                    calFechaNac.Visible = false;
                    calFechaIngreso.Visible = false;
                    CargarEspecialidades();
                    CargarInstituciones();
                    CargarProfesional(idPersona);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('ID de profesional no válido.');", true);
                }
            }
        }

        protected void btnMostrarCalendario_Click(object sender, EventArgs e)
        {

            calFechaNac.Visible = !calFechaNac.Visible;

        }
        protected void btnMostrarCalendarioIngreso_Click(object sender, EventArgs e)
        {
            calFechaIngreso.Visible = !calFechaIngreso.Visible;

        }

        private void CargarEspecialidades()
        {
            ProfesionalNegocio negocio = new ProfesionalNegocio();
            var especialidades = negocio.obtenerEspecialidades();
            ddlEspecialidades.DataSource = especialidades;
            ddlEspecialidades.DataTextField = "NombreEspecialidad";
            ddlEspecialidades.DataValueField = "IdEspecialidad";
            ddlEspecialidades.DataBind();
            ddlEspecialidades.Items.Insert(0, new ListItem("-- Seleccionar Especialidad --", ""));
        }

        private void CargarInstituciones()
        {
            ProfesionalNegocio negocio = new ProfesionalNegocio();
            var instituciones = negocio.obtenerInstituciones();
            ddlInstituciones.DataSource = instituciones;
            ddlInstituciones.DataTextField = "Nombre";
            ddlInstituciones.DataValueField = "IdInstitucion";
            ddlInstituciones.DataBind();
            ddlInstituciones.Items.Insert(0, new ListItem("-- Seleccionar Institución --", ""));
        }

        private void CargarProfesional(int idPersona)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            accesoDatos.setConsulta(@"
                                        	SELECT
                                                    p.IDPERSONA,
                                                    p.DNI,
                                                    p.NOMBRE,
                                                    p.APELLIDO,
                                                    p.FECHA_NACIMIENTO,
                                                    c.EMAIL,
                                                    c.TELEFONO,
                                                    c.DIRECCION,
                                                    u.NOMBRE_USUARIO AS Usuario,
						                            u.CONTRASENA AS Contraseña,
						                            u.TIPOUSUARIO,
						                            pr.FECHA_INGRESO,
						                            pr.MATRICULA,
						                            e.IDESPECIALIDAD,
                                                    STRING_AGG(e.ESPECIALIDAD, ', ') AS Especialidades,
						                            I.IDINSTITUCION,
						                            I.NOMBRE_INSTITUCION
                                                    FROM
                                                    PROFESIONAL pr
                                                            INNER JOIN PERSONA p ON pr.IDPERSONA = p.IDPERSONA
                                                            INNER JOIN CONTACTO c ON p.IDPERSONA = c.IDPERSONA
                                                            INNER JOIN USUARIO u ON pr.IDUSUARIO = u.IDUSUARIO
					                                        INNER JOIN INSTITUCION I ON I.IDINSTITUCION=PR.IDINSTITUCION
                                                            LEFT JOIN PROFESIONAL_POR_ESPECIALIDAD ppe ON pr.IDPROFESIONAL = ppe.IDPROFESIONAL
                                                            LEFT JOIN ESPECIALIDAD e ON ppe.IDESPECIALIDAD = e.IDESPECIALIDAD
                                                    WHERE
                                                      p.IDPERSONA = @IDPERSONA
                                                    GROUP BY
                                                        p.IDPERSONA,    
                                                        p.DNI,
                                                        p.NOMBRE,
                                                        p.APELLIDO,
                                                        p.FECHA_NACIMIENTO,
                                                        c.EMAIL,
                                                        c.TELEFONO,
                                                        c.DIRECCION,
                                                        u.NOMBRE_USUARIO,
						                                u.CONTRASENA,
						                                u.TIPOUSUARIO,
						                                pr.FECHA_INGRESO,
						                                pr.MATRICULA,
						                                e.IDESPECIALIDAD,
						                                I.IDINSTITUCION,
						                                I.NOMBRE_INSTITUCION;");

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
                    txtContraseña.Text = accesoDatos.Lector["Contrasena"].ToString();
                    txtTipoUsuario.Text = accesoDatos.Lector["TipoUsuario"].ToString();
                    txtFechaIngreso.Text = Convert.ToDateTime(accesoDatos.Lector["FechaIngreso"]).ToString("dd/MM/yyyy");
                    txtMatricula.Text = accesoDatos.Lector["Matricula"].ToString();
                    ddlEspecialidades.Text = accesoDatos.Lector["Especialidades"].ToString();
                    ddlInstituciones.Text = accesoDatos.Lector["NombreInstitucion"].ToString();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('No se encontraron detalles para este profesional.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", $"alert('Error al cargar los detalles: {ex.Message}');", true);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        protected void btnModificarProfesional_Click(object sender, EventArgs e)
        {

        }
    }
}
