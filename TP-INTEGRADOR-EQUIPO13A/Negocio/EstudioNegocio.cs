using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
    {
        public class EstudioNegocio
        {
        public void CargarEstudio(Estudio estudio)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO Estudios (id_paciente, nombre_archivo, ruta_archivo, tipo_estudio, fecha_estudio) " +
                                  "VALUES (@idPaciente, @nombreArchivo, @rutaArchivo, @tipoEstudio, @fechaEstudio)";

                accesoDatos.setConsulta(consulta);
                accesoDatos.setearParametro("@idPaciente", estudio.IdPaciente);
                accesoDatos.setearParametro("@nombreArchivo", estudio.NombreArchivo);
                accesoDatos.setearParametro("@rutaArchivo", estudio.RutaArchivo);
                accesoDatos.setearParametro("@tipoEstudio", estudio.TipoEstudio);
                accesoDatos.setearParametro("@fechaEstudio", estudio.FechaEstudio);

                Console.WriteLine("Consulta: " + consulta);
                Console.WriteLine("Parametros:");
                Console.WriteLine("idPaciente: " + estudio.IdPaciente);
                Console.WriteLine("nombreArchivo: " + estudio.NombreArchivo);
                Console.WriteLine("rutaArchivo: " + estudio.RutaArchivo);
                Console.WriteLine("tipoEstudio: " + estudio.TipoEstudio);
                Console.WriteLine("fechaEstudio: " + estudio.FechaEstudio);

                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar el estudio: " + ex.Message);
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

    }
}

