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
                                    WHERE PE.ACTIVO=1
                                    GROUP BY PE.IDPERSONA, PE.NOMBRE, PE.APELLIDO, I.NOMBRE_INSTITUCION
                                    ORDER BY PE.APELLIDO ASC;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();
                    aux.Persona = new Persona
                    {
                        IdPersona = (int)datos.Lector["IDPERSONA"],
                        Nombre = (string)datos.Lector["NOMBRE"],
                        Apellido = (string)datos.Lector["APELLIDO"]
                    };
                    string especialidadesCadena = (string)datos.Lector["ESPECIALIDADES"];
                    if (!string.IsNullOrEmpty(especialidadesCadena))
                    {
                        aux.Especialidades = especialidadesCadena
                            .Split(',')
                            .Select(especialidad => new Especialidad { NombreEspecialidad = especialidad.Trim() })
                            .ToList();
                    }
                    else
                    {
                        aux.Especialidades = new List<Especialidad>();
                    }

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

        public List<Profesional> listar_porID(int ID)
        {
            List<Profesional> lista = new List<Profesional>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"
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

                datos.setearParametro("@IDPERSONA", ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();

                    aux.Persona.Dni = (int)datos.Lector["DNI"];
                    aux.Persona.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Persona.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Persona.FechaNacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];
                    aux.Persona.ContactoCliente.Email = (string)datos.Lector["EMAIL"];
                    aux.Persona.ContactoCliente.telefono = (string)datos.Lector["TELEFONO"];
                    aux.Persona.ContactoCliente.Direccion = (string)datos.Lector["DIRECCION"];
                    aux.Usuario.User = (string)datos.Lector["USUARIO"];
                    string especialidadesCadena = (string)datos.Lector["ESPECIALIDADES"];
                    aux.Especialidades = especialidadesCadena
                        .Split(',')
                        .Select(especialidad => new Especialidad { NombreEspecialidad = especialidad.Trim() })
                        .ToList();

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

        public void Agregar(Profesional aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_AGREGAR_PROFESIONAL");

                datos.setearParametro("@DNI", aux.Persona.Dni);
                datos.setearParametro("@NOMBRE", aux.Persona.Nombre);
                datos.setearParametro("@APELLIDO", aux.Persona.Apellido);
                datos.setearParametro("@FECHA_NACIMIENTO", aux.Persona.FechaNacimiento);
                datos.setearParametro("@EMAIL", aux.Persona.ContactoCliente.Email);
                datos.setearParametro("@TELEFONO", aux.Persona.ContactoCliente.telefono);
                datos.setearParametro("@DIRECCION", aux.Persona.ContactoCliente.Direccion);
                datos.setearParametro("@USUARIO", aux.Usuario.User);
                datos.setearParametro("@CONTRASENA", aux.Usuario.Password);
                datos.setearParametro("@TIPO_USUARIO", aux.Usuario.tipousuario);
                datos.setearParametro("@FECHA_INGRESO", aux.FechaIngreso);
                datos.setearParametro("@MATRICULA", aux.Matricula);
                datos.setearParametro("@NOMBRE_INSTITUCION", aux.Institucion.Nombre);
                string especialidades = string.Join(",", aux.Especialidades.Select(e => e.NombreEspecialidad));
                datos.setearParametro("@ESPECIALIDADES", especialidades);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                datos.cerrarConexion();
            }
        }




        public List<Especialidad> obtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT IDESPECIALIDAD, ESPECIALIDAD FROM ESPECIALIDAD");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad especialidad = new Especialidad
                    {
                        IdEspecialidad = (int)datos.Lector["IDESPECIALIDAD"],
                        NombreEspecialidad = datos.Lector["ESPECIALIDAD"].ToString()
                    };

                    especialidades.Add(especialidad);
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

            return especialidades;
        }


        public List<Institucion> obtenerInstituciones()
        {
            List<Institucion> instituciones = new List<Institucion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT IDINSTITUCION, NOMBRE_INSTITUCION FROM INSTITUCION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Institucion institucion = new Institucion
                    {
                        IdInstitucion = (int)datos.Lector["IDINSTITUCION"],
                        Nombre = datos.Lector["NOMBRE_INSTITUCION"].ToString()
                    };

                    instituciones.Add(institucion);
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

            return instituciones;
        }


        public int ModificarProfesional(Profesional seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MODIFICAR_PROFESIONAL");
                datos.setearParametro("@IDPERSONA", seleccionado.Persona.IdPersona);
                datos.setearParametro("@DNI", seleccionado.Persona.Dni);
                datos.setearParametro("@NOMBRE", seleccionado.Persona.Nombre);
                datos.setearParametro("@APELLIDO", seleccionado.Persona.Apellido);
                datos.setearParametro("@FECHA_NACIMIENTO", seleccionado.Persona.FechaNacimiento);
                datos.setearParametro("@EMAIL", seleccionado.Persona.ContactoCliente.Email);
                datos.setearParametro("@TELEFONO", seleccionado.Persona.ContactoCliente.telefono);
                datos.setearParametro("@DIRECCION", seleccionado.Persona.ContactoCliente.Direccion);
                datos.ejecutarAccion();


                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
