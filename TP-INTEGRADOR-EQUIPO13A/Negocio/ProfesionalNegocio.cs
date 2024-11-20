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
                    aux.Dni = (string)datos.Lector["DNI"];


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
                        aux.Dni = (string)datos.Lector["DNI"];
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
                datos.setConsulta(@"SELECT p.activo, p.id_profesional,p.nombre,p.apellido ,STRING_AGG(e.nombre, ', ') AS especialidades,i.nombre as institucion
                                    FROM profesionales p
                                    INNER JOIN profesionales_especialidades pe on pe.id_profesional=p.id_profesional
                                    INNER JOIN especialidades e on e.id_especialidad=pe.id_especialidad
                                    INNER JOIN profesionales_instituciones pxi on pxi.id_profesional=p.id_profesional
                                    INNER JOIN instituciones i on i.id_institucion=pxi.id_institucion
                           
                                    GROUP BY p.id_profesional,p.nombre,p.apellido ,i.nombre, p.activo
                                    ORDER BY p.apellido ASC;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();
                    aux.Persona = new Persona
                    {
                        IdPersona = (int)datos.Lector["id_profesional"],
                        Nombre = (string)datos.Lector["nombre"],
                        Apellido = (string)datos.Lector["apellido"]
                    };
                    string especialidadesCadena = (string)datos.Lector["especialidades"];
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
                        Nombre = (string)datos.Lector["institucion"]
                    };

                    aux.IdProfesional = (int)datos.Lector["id_profesional"];

                    aux.Estado = (bool)datos.Lector["activo"];

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
                datos.setConsulta(@"SELECT p.activo, p.id_profesional, p.dni,p.nombre,p.apellido,p.fecha_nacimiento,p.email,p.telefono,p.direccion,u.usuario, u.contraseña, p.matricula, p.fecha_ingreso, STRING_AGG(e.nombre, ', ') AS especialidades
                                    FROM profesionales p
                                    LEFT JOIN usuarios u ON u.id_profesional=p.id_profesional
                                    LEFT JOIN profesionales_especialidades pe on pe.id_profesional=p.id_profesional
                                    LEFT JOIN especialidades e on e.id_especialidad=pe.id_especialidad
                                    WHERE p.id_profesional= @IDPROFESIONAL
                                    GROUP BY p.dni,p.nombre,p.apellido,p.fecha_nacimiento,p.email,p.telefono,p.direccion,u.usuario,u.contraseña, p.activo, p.id_profesional,  p.matricula, p.fecha_ingreso;");

                datos.setearParametro("@IDPROFESIONAL", ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();

                    aux.Persona.Dni = (string)datos.Lector["dni"];
                    aux.Persona.Nombre = (string)datos.Lector["nombre"];
                    aux.Persona.Apellido = (string)datos.Lector["apellido"];
                    aux.Persona.FechaNacimiento = (DateTime)datos.Lector["fecha_nacimiento"];
                    aux.Persona.ContactoCliente.Email = (string)datos.Lector["email"];
                    aux.Persona.ContactoCliente.telefono = (string)datos.Lector["telefono"];
                    aux.Persona.ContactoCliente.Direccion = (string)datos.Lector["direccion"];
                    aux.Usuario.User = (string)datos.Lector["usuario"];
                    aux.Usuario.Password = datos.Lector["contraseña"].ToString();
                    string especialidadesCadena = (string)datos.Lector["especialidades"];
                    aux.Especialidades = especialidadesCadena
                        .Split(',')
                        .Select(especialidad => new Especialidad { NombreEspecialidad = especialidad.Trim() })
                        .ToList();
                    aux.Estado = (bool)datos.Lector["activo"];
                    aux.IdProfesional = (int)datos.Lector["id_profesional"];
                    aux.Matricula = datos.Lector["matricula"].ToString();
                    aux.FechaIngreso = (DateTime)datos.Lector["fecha_ingreso"];
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
        public void modificarEstado(Profesional profesional)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_MODIFICAR_ESTADO_PROFESIONAL");
                datos.setearParametro("@ID_PROFESIONAL", profesional.IdProfesional);
                datos.setearParametro("@ACTIVO", profesional.Estado);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Agregar(Profesional aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Llamada al procedimiento almacenado
                datos.setearProcedimiento("SP_AGREGAR_PROFESIONAL");

                datos.setearParametro("@DNI", aux.Persona.Dni);
                datos.setearParametro("@NOMBRE", aux.Persona.Nombre);
                datos.setearParametro("@APELLIDO", aux.Persona.Apellido);
                datos.setearParametro("@FECHA_NACIMIENTO", aux.Persona.FechaNacimiento.ToString("yyyy-MM-dd"));
                datos.setearParametro("@EMAIL", aux.Persona.ContactoCliente.Email);
                datos.setearParametro("@TELEFONO", aux.Persona.ContactoCliente.telefono);
                datos.setearParametro("@DIRECCION", aux.Persona.ContactoCliente.Direccion);
                datos.setearParametro("@USUARIO", aux.Usuario.User);
                datos.setearParametro("@CONTRASENA", aux.Usuario.Password);
                datos.setearParametro("@TIPO_USUARIO", aux.Usuario.tipousuario);
                datos.setearParametro("@FECHA_INGRESO", aux.FechaIngreso.ToString("yyyy-MM-dd"));
                datos.setearParametro("@MATRICULA", aux.Matricula);

                // Crear la cadena de especialidades (si las hay)
                string especialidades = string.Join(",", aux.Especialidades.Select(e => e.IdEspecialidad.ToString()));
                datos.setearParametro("@ESPECIALIDADES", especialidades);

                // Si no hay institución asignada, pasa un valor vacío
                string instituciones = aux.Institucion != null ? aux.Institucion.IdInstitucion.ToString() : "";
                datos.setearParametro("@INSTITUCIONES", instituciones);

                // Ejecutar la inserción
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




        private int ObtenerIdProfesional(Profesional aux)
        {
            int idProfesional = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT id_profesional FROM profesionales WHERE dni = @DNI");
                datos.setearParametro("@DNI", aux.Persona.Dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    idProfesional = (int)datos.Lector["id_profesional"];
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
            return idProfesional;
        }





        public List<Especialidad> obtenerEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT id_especialidad, nombre FROM especialidades");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad especialidad = new Especialidad
                    {
                        IdEspecialidad = (int)datos.Lector["id_especialidad"],
                        NombreEspecialidad = datos.Lector["nombre"].ToString()
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
                datos.setConsulta("SELECT id_institucion,nombre FROM instituciones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Institucion institucion = new Institucion
                    {
                        IdInstitucion = (int)datos.Lector["id_institucion"],
                        Nombre = datos.Lector["nombre"].ToString()
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
                    datos.setearParametro("@ID_PROFESIONAL", seleccionado.IdProfesional);
                    datos.setearParametro("@DNI", seleccionado.Persona.Dni);
                    datos.setearParametro("@NOMBRE", seleccionado.Persona.Nombre);
                    datos.setearParametro("@APELLIDO", seleccionado.Persona.Apellido);
                    datos.setearParametro("@FECHA_NACIMIENTO", seleccionado.Persona.FechaNacimiento);
                    datos.setearParametro("@EMAIL", seleccionado.Persona.ContactoCliente.Email);
                    datos.setearParametro("@TELEFONO", seleccionado.Persona.ContactoCliente.telefono);
                    datos.setearParametro("@DIRECCION", seleccionado.Persona.ContactoCliente.Direccion);
                    datos.setearParametro("@MATRICULA", seleccionado.Matricula);
                    datos.setearParametro("@FECHA_ING", seleccionado.FechaIngreso);
                    datos.setearParametro("@USUARIO", seleccionado.Usuario.User);
                    datos.setearParametro("@PASSWORD", seleccionado.Usuario.Password);
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

