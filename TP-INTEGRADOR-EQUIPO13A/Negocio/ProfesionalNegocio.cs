using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProfesionalNegocio
    {
        public List<Persona> listar()
        {
            List<Persona> lista = new List<Persona>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setConsulta("select P.APELLIDO, P.NOMBRE, P.DNI from PERSONA as P inner join PROFESIONAL as PR on PR.IDPERSONA = P.IDPERSONA ORDER BY P.APELLIDO ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Dni = datos.Lector.GetInt32(2);


                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;

        }

        public Persona listar(int DNI)
        {
            Persona aux = null;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("select P.APELLIDO, P.NOMBRE, P.DNI from PERSONA as P inner join PACIENTE as PA on PA.IDPERSONA = P.IDPERSONA WHERE P.DNI = @DNI");
                datos.setearParametro("@DNI", DNI);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (aux == null)
                    {
                        aux = new Persona();
                        aux.Dni = (int)datos.Lector["DNI"];
                        aux.Apellido = (string)datos.Lector["APELLIDO"];
                        aux.Nombre = (string)datos.Lector["NOMBRE"];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return aux;
        }

        public List<Profesional> listarProfesionales()
        {
            List<Profesional> lista = new List<Profesional>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta(@"SELECT  PE.IDPERSONA,PE.NOMBRE,PE.APELLIDO,STRING_AGG(E.ESPECIALIDAD, ', ') AS ESPECIALIDADES,I.NOMBRE_INSTITUCION
                                    FROM PERSONA PE
                                    INNER JOIN PROFESIONAL P ON PE.IDPERSONA = P.IDPERSONA
                                    INNER JOIN PROFESIONAL_POR_ESPECIALIDAD PXE ON PXE.IDPROFESIONAL = P.IDPROFESIONAL
                                    INNER JOIN ESPECIALIDAD E ON E.IDESPECIALIDAD = PXE.IDESPECIALIDAD
                                    INNER JOIN PROFESIONAL_POR_INSTITUCION PPI ON PPI.IDPROFESIONAL = P.IDPROFESIONAL
                                    INNER JOIN INSTITUCION I ON I.IDINSTITUCION = PPI.IDINSTITUCION
                                    GROUP BY PE.IDPERSONA, PE.NOMBRE, PE.APELLIDO, I.NOMBRE_INSTITUCION
                                    ORDER BY PE.APELLIDO ASC;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();
                    aux.Persona = new Persona
                    {
                        Nombre = (string)datos.Lector["NOMBRE"],
                        Apellido = (string)datos.Lector["APELLIDO"]
                    };
                    aux.Especialidades = (string)datos.Lector["ESPECIALIDADES"];
                    aux.Institucion = new Institucion
                    {
                        Nombre = (string)datos.Lector["NOMBRE_INSTITUCION"]
                    };

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }


    }
}
