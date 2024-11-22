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
            if (!IsPostBack) 
            {
                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"], out int idPaciente))
                    {
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
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    string filePath = Path.Combine(directoryPath, fileName);

                    FileUploadEstudio.SaveAs(filePath);

                    if (File.Exists(filePath))
                    {
                        lblMensaje.Text = "El estudio se cargó correctamente.";
                        lblMensaje.CssClass = "mensaje-formulario mensaje-exito";
                        lblMensaje.Visible = true;

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
                        lblMensaje.Text = "Ocurrió un error al cargar el estudio.";
                        lblMensaje.CssClass = "mensaje-formulario mensaje-error";
                        lblMensaje.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Ocurrió un error al cargar el estudio.";
                    lblMensaje.CssClass = "mensaje-formulario mensaje-error";
                    lblMensaje.Visible = true;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, seleccione un archivo.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        }
    }
}
