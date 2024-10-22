using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Dominio;
using System.Reflection;

namespace Negocio
{
    internal class PacienteNegocio
    {
        
            public List<Persona> listar()
            {
                List<Persona> lista = new List<Persona>();
                SqlConnection conexion = new SqlConnection();
                SqlCommand comando = new SqlCommand();
                SqlDataReader lector;

                try
                {
                    conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ClinicaUTN; Integrated Security=True;";
                    comando.CommandType = System.Data.CommandType.Text;
                    comando.CommandText = "select P.APELLIDO, P.NOMBRE, P.DNI from PERSONA as P inner join PACIENTE as PA on PA.IDPERSONA = P.IDPERSONA ORDER BY P.APELLIDO ASC";

                    comando.Connection = conexion;

                    conexion.Open();
                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Persona aux = new Persona();
                        aux.Apellido = (string)lector["APELLIDO"];
                        aux.Nombre = (string)lector["Nombre"];
                        aux.Dni = lector.GetInt32(2);

                 
                        lista.Add(aux);
                    }

                    conexion.Close();
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }


            }

            public void eliminar(int id)
            {
                try
                {
                    AccesoDatos datos = new AccesoDatos();
                    datos.setConsulta("delete from PERSONA where id=@id");
                    datos.setearParametro("@id", id);
                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }


            private void ActualizarPaciente(Persona persona)
            {
                AccesoDatos datos = new AccesoDatos();
                {
                    try
                    {
                        string consultaPaciente = "UPDATE persona....";

                        datos.setConsulta(consultaPaciente);
                        
                        datos.setearParametro("@Nombre", persona.Nombre);
                        datos.setearParametro("@Descripcion", persona.Apellido);
                        datos.setearParametro("@IdMarca", persona.Dni);
                        

                        datos.ejecutarAccion();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }


            public Persona listar(int DNI)
        {
            Persona aux = null;
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=ClinicaUTN; Integrated Security=True;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select P.APELLIDO, P.NOMBRE, P.DNI from PERSONA as P inner join PACIENTE as PA on PA.IDPERSONA = P.IDPERSONA WHERE P.DNI = @DNI";

                comando.Parameters.AddWithValue("@DNI", DNI);
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    if (aux == null)
                    {
                        aux = new Persona();
                        aux.Dni = (int)lector["DNI"];
                        aux.Apellido = (string)lector["APELLIDO"];
                        aux.Nombre = (string)lector["NOMBRE"];
                    }
                }

                lector.Close();
                conexion.Close();
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close(); 
                }
            }
        }

    }
}
