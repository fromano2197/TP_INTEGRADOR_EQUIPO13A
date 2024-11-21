using iText.Kernel.Pdf;
using iText.Layout.Element;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iText.Layout;

namespace CLINICA_APP_WEB
{
    public partial class misPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Session["idProfesional"] != null ? int.Parse(Session["idProfesional"].ToString()) : 0;
                PacienteNegocio negocio = new PacienteNegocio();
                Session.Add("listarPacientes", negocio.listarPorProfesional(id));
                repRepeater.DataSource = Session["listarPacientes"];
                repRepeater.DataBind();
            }
        }

        protected void btnDetalles_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Detalles")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("DetallesPacientes.aspx?id=" + id);
            }

        }

        protected void btnHistoria_Command(object sender, CommandEventArgs e)
        {
            {

                int idPaciente = Convert.ToInt32(e.CommandArgument);

                GenerarHistoriaClinicaPDF(idPaciente);
            

        }
    }
        public void GenerarHistoriaClinicaPDF(int idPaciente)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(ms);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                document.Add(new Paragraph("Historia Clínica - Turnos"));
                SqlDataReader reader = ObtenerDatosHistoriaClinica(idPaciente);

                while (reader.Read())
                {
                    document.Add(new Paragraph($"Fecha: {reader["fecha"]}"));
                    document.Add(new Paragraph($"Hora: {reader["hora"]}"));
                    document.Add(new Paragraph($"Medico: {reader["Medico"]}"));
                    document.Add(new Paragraph($"Especialidad: {reader["especialidad"]}"));
                    document.Add(new Paragraph($"Institución: {reader["institucion"]}"));
                    document.Add(new Paragraph($"Estado: {reader["estado"]}"));
                    document.Add(new Paragraph($"Observaciones: {reader["observaciones"]}"));
                    document.Add(new Paragraph("------------------------------------------------------------"));
                }

                reader.Close();
                document.Close();

                string filePath = Server.MapPath("~/HistorialClinico.pdf");
                File.WriteAllBytes(filePath, ms.ToArray());

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=HistorialClinico.pdf");
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
        }

        private SqlDataReader ObtenerDatosHistoriaClinica(int idPaciente)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            string consulta = @"SELECT T.fecha, T.hora, P.nombre + ' ' + P.apellido AS Medico, E.nombre AS especialidad, 
                        T.id_turno, T.id_paciente, T.id_profesional, T.id_especialidad, T.id_institucion, 
                        I.nombre as institucion, I.direccion AS direccion, T.estado, T.observaciones
                        FROM TURNOS T
                        INNER JOIN profesionales P ON P.id_profesional = T.id_profesional
                        INNER JOIN especialidades E ON E.id_especialidad = T.id_especialidad
                        INNER JOIN instituciones I ON I.id_institucion = T.id_institucion
                        WHERE P.activo = 1 AND E.activo = 1 AND I.activo = 1 AND T.id_paciente = @idPaciente AND T.estado='atendido'
                        ORDER BY T.fecha DESC";

            accesoDatos.setConsulta(consulta);
            accesoDatos.setearParametro("@idPaciente", idPaciente);

            accesoDatos.ejecutarLectura();

            return accesoDatos.Lector;

        }


    }
}
