using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CLINICA_APP_WEB
{
    public partial class CargarEstudios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Solo ejecutar esta lógica en la primera carga de la página
            {
                // Verificar si el parámetro "id" está presente en la URL
                if (Request.QueryString["id"] != null)
                {
                    // Intentar convertir el valor del parámetro a un entero
                    if (int.TryParse(Request.QueryString["id"], out int idPaciente))
                    {
                        // Guarda el ID del paciente en una variable privada, si es necesario
                        ViewState["idPaciente"] = idPaciente;
                    }
                    else
                    {
                        lblMensaje.Text = "El parámetro 'id' no es válido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Visible = true;
                        btnCargarEstudio.Enabled = false;
                    }
                }
                else
                {
                    lblMensaje.Text = "No se especificó el ID del paciente en la URL.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                    btnCargarEstudio.Enabled = false;
                }
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("EstudiosDePacientes.aspx");  
        }

        protected void btnCargarEstudio_Click(object sender, EventArgs e)
        {
            if (FileUploadEstudio.HasFile)
            {
                try
                {
                    string fileName = FileUploadEstudio.FileName;
                    string directoryPath = @"C:\Users\roman\OneDrive\Desktop\Estudios\";

                    // Asegurarse de que la carpeta existe
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string filePath = Path.Combine(directoryPath, fileName);

                    // Intentar guardar el archivo
                    FileUploadEstudio.SaveAs(filePath);

                    // Verificar si el archivo realmente se guardó
                    if (File.Exists(filePath))
                    {
                        lblMensaje.Text = "Archivo guardado exitosamente.";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        lblMensaje.Visible = true;  // Asegúrate de que el mensaje se vea

                        // Cargar el archivo en la base de datos
                        Estudio nuevoEstudio = new Estudio
                        {
                            IdPaciente = (int)ViewState["idPaciente"],
                            NombreArchivo = fileName,
                            RutaArchivo = filePath,
                            TipoEstudio = txtTipoEstudio.Text,
                            FechaEstudio = DateTime.Now
                        };

                        EstudioNegocio negocioEstudio = new EstudioNegocio();
                        negocioEstudio.CargarEstudio(nuevoEstudio);
                    }
                    else
                    {
                        lblMensaje.Text = "Error al guardar el archivo.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        lblMensaje.Visible = true;  // Asegúrate de que el mensaje se vea
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error al cargar el archivo: " + ex.Message;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;  // Asegúrate de que el mensaje se vea
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, seleccione un archivo.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;  // Asegúrate de que el mensaje se vea
            }
        }
    }
}
