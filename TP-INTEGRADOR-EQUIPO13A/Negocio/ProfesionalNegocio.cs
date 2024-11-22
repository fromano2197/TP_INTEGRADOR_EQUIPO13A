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
                datos.setConsulta(@"SELECT p.activo, p.id_profesional, p.nombre, p.apellido,
                                (SELECT STRING_AGG(e.nombre, ', ')
                                FROM profesionales_especialidades pe
                                INNER JOIN especialidades e ON e.id_especialidad = pe.id_especialidad
                                WHERE pe.id_profesional = p.id_profesional AND pe.activo = 1) AS especialidades,
                                (SELECT STRING_AGG(i.nombre, ', ')
                                FROM profesionales_instituciones pxi
                                INNER JOIN instituciones i ON i.id_institucion = pxi.id_institucion
                                WHERE pxi.id_profesional = p.id_profesional AND pxi.activo = 1) AS instituciones
                                FROM profesionales p
                                WHERE p.activo = 1
                                ORDER BY p.apellido ASC;;");
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

                    string institucuionesCadena = (string)datos.Lector["instituciones"];
                    if (!string.IsNullOrEmpty(especialidadesCadena))
                    {
                        aux.Institucion = institucuionesCadena
                            .Split(',')
                            .Select(institucion => new Institucion { Nombre = institucion.Trim() })
                            .ToList();
                    }
                    else
                    {

                        aux.Institucion = new List<Institucion>();


                    }

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
                datos.setConsulta(@"SELECT p.activo, p.id_profesional, p.dni, p.fecha_nacimiento, p.email, p.direccion, p.telefono,p.nombre,p.apellido,u.usuario,u.contraseña,p.matricula, 	p.fecha_ingreso,
                (SELECT STRING_AGG(e.nombre, ', ')
                 FROM profesionales_especialidades pe
                 INNER JOIN especialidades e ON e.id_especialidad = pe.id_especialidad
                 WHERE pe.id_profesional = p.id_profesional AND pe.activo = 1) AS especialidades,

                (SELECT STRING_AGG(i.nombre, ', ')
                 FROM profesionales_instituciones pxi
                 INNER JOIN instituciones i ON i.id_institucion = pxi.id_institucion
                 WHERE pxi.id_profesional = p.id_profesional AND pxi.activo = 1) AS instituciones
                 FROM profesionales p
	             INNER JOIN USUARIOS as U on p.id_profesional = U.id_profesional
                 WHERE p.activo = 1 and p.id_profesional = @IDPROFESIONAL
                 ORDER BY p.apellido ASC");

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
                    string institucionescadena = (string)datos.Lector["instituciones"];
                    aux.Institucion = institucionescadena
                       .Split(',')
                       .Select(institucion => new Institucion { Nombre = institucion.Trim() })
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


                string especialidades = string.Join(",", aux.Especialidades.Select(e => e.IdEspecialidad.ToString()));
                datos.setearParametro("@ESPECIALIDADES", especialidades);


                string instituciones = string.Join(",", aux.Institucion.Select(e => e.IdInstitucion.ToString()));
                datos.setearParametro("@INSTITUCIONES", instituciones);

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
        public bool ExisteUsuario(string usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = @Usuario;";

                datos.setConsulta(query);
                datos.setearParametro("@Usuario", usuario);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = datos.Lector.GetInt32(0);
                    return count > 0;
                }

                return false;
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

        public bool ExisteDni(string dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = "SELECT COUNT(*) FROM profesionales WHERE dni = @Dni;";

                datos.setConsulta(query);
                datos.setearParametro("@Dni", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = datos.Lector.GetInt32(0);
                    return count > 0;
                }

                return false;
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

        public bool ExisteEmail(string email)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = @"
        SELECT COUNT(*)
        FROM profesionales
        WHERE email = @Email";

                datos.setConsulta(query);
                datos.setearParametro("@Email", email);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    int count = datos.Lector.GetInt32(0);
                    return count > 0;
                }

                return false;
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

