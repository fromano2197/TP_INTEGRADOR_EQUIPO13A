using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace CLINICA_APP_WEB
{
    public partial class MisEstudios : System.Web.UI.Page
    {
        private AccesoDatos accesoDatos = new AccesoDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPaciente"] != null)
                {
                    int idPaciente = Convert.ToInt32(Session["idPaciente"]);
                    CargarEstudios(idPaciente);
                }

            }
        }


        private void CargarEstudios(int idPaciente)
        {
            DataTable estudios = new DataTable();

            try
            {
                string consulta = "SELECT id_estudio, tipo_estudio, fecha_estudio, nombre_archivo, ruta_archivo " +
                                  "FROM Estudios WHERE id_paciente = @IDPACIENTE";
                accesoDatos.setConsulta(consulta);

                accesoDatos.setearParametro("@IDPACIENTE", idPaciente);

                accesoDatos.ejecutarLectura();

                estudios.Load(accesoDatos.Lector);

                gvEstudios.DataSource = estudios;
                gvEstudios.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al cargar los estudios: " + ex.Message + "');</script>");
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        protected void gvEstudios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {
                string idEstudio = e.CommandArgument.ToString();

                DescargarEstudio(idEstudio);
            }
        }


        private void DescargarEstudio(string idEstudio)
        {
            string archivoEstudio = ObtenerArchivoEstudio(idEstudio);

            if (!string.IsNullOrEmpty(archivoEstudio) && System.IO.File.Exists(archivoEstudio))
            {
                Response.ContentType = "application/pdf"; 
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + System.IO.Path.GetFileName(archivoEstudio));
                Response.TransmitFile(archivoEstudio);
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('El estudio no está disponible para descargar.');</script>");
            }
        }

        private string ObtenerArchivoEstudio(string idEstudio)
        {
            string archivoEstudio = string.Empty;

            try
            {
                string consulta = "SELECT ruta_archivo FROM Estudios WHERE id_estudio = @idEstudio";
                accesoDatos.setConsulta(consulta);
                accesoDatos.setearParametro("@idEstudio", idEstudio);
                accesoDatos.ejecutarLectura();
                if (accesoDatos.Lector.Read())
                {
                    archivoEstudio = accesoDatos.Lector["ruta_archivo"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al obtener la ruta del archivo: " + ex.Message + "');</script>");
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
            return archivoEstudio;
        }
    }
}
