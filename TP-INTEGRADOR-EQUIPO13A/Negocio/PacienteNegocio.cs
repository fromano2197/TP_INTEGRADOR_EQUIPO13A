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
    public class PacienteNegocio
    {

        public List<Persona> listar()
        {
            List<Persona> lista = new List<Persona>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select id_paciente,apellido,nombre,dni from pacientes where activo=1 order by apellido asc;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.IdPersona = datos.Lector.GetInt32(0);
                    aux.Apellido = (string)datos.Lector["apellido"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.Dni = (string)datos.Lector["dni"];
                    


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

        public List<Persona> listarPorProfesional(int id)
        {
            List<Persona> lista = new List<Persona>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT p.id_paciente, p.apellido, p.nombre, p.dni FROM pacientes_por_profesional AS pxp " +
                                "INNER JOIN pacientes AS p ON p.id_paciente = pxp.id_paciente " +
                                "WHERE pxp.id_profesional = @id;");

                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.IdPersona= datos.Lector.GetInt32(0);
                    aux.Apellido = (string)datos.Lector["apellido"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.Dni = (string)datos.Lector["dni"];



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

        public void eliminarPaciente(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_ELIMINAR_PACIENTE_PERSONA");
                datos.setearParametro("@ID_PACIENTE", id);
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


        public Persona listar(int id)
        {
            Persona aux = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select apellido,nombre,dni from pacientes WHERE id_paciente = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    if (aux == null)
                    {
                        aux = new Persona();
                        aux.Dni =  (string)datos.Lector["dni"];
                        aux.Apellido = (string)datos.Lector["apellido"];
                        aux.Nombre = (string)datos.Lector["nombre"];
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
        public int buscarIDPaciente(int DNI)
        {
            Paciente aux = new Paciente();
            AccesoDatos datos = new AccesoDatos();
            int IDPACIENTE = 0;
            try
            {
                datos.setConsulta("select id_paciente from pacientes where dni=@DNI;");
                datos.setearParametro("@DNI", DNI);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.IdPaciente = int.Parse(datos.Lector["id_paciente"].ToString());
                    IDPACIENTE = aux.IdPaciente;
                    
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
            return IDPACIENTE;
        }


        public int  nuevoPaciente(Paciente nuevo, Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                datos.setearProcedimiento("SP_AGREGAR_PACIENTE");
                datos.setearParametro("@DNI", nuevo.DatosPersona.Dni);
                datos.setearParametro("@NOMBRE", nuevo.DatosPersona.Nombre);
                datos.setearParametro("@APELLIDO", nuevo.DatosPersona.Apellido);
                datos.setearParametro("@FECHA_NACIMIENTO", nuevo.DatosPersona.FechaNacimiento);
                datos.setearParametro("@EMAIL", nuevo.DatosPersona.ContactoCliente.Email);
                datos.setearParametro ("@TELEFONO", nuevo.DatosPersona.ContactoCliente.telefono);
                datos.setearParametro("@DIRECCION", nuevo.DatosPersona.ContactoCliente.Direccion);
                datos.setearParametro("@USUARIO", usuario.User);
                datos.setearParametro("@CONTRASENA", usuario.Password);
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
        public List<Paciente> listar_porID(int ID)
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"select nombre,apellido,fecha_nacimiento,dni,telefono,email,direccion from pacientes where id_paciente=@IDPACIENTE;");

                datos.setearParametro("@IDPACIENTE", ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.DatosPersona.Dni = (string)datos.Lector["dni"];
                    aux.DatosPersona.Nombre = (string)datos.Lector["nombre"];
                    aux.DatosPersona.Apellido = (string)datos.Lector["apellido"];
                    aux.DatosPersona.FechaNacimiento = (DateTime)datos.Lector["fecha_nacimiento"];
                    aux.DatosPersona.ContactoCliente.Email = (string)datos.Lector["email"];
                    aux.DatosPersona.ContactoCliente.telefono = (string)datos.Lector["telefono"];
                    aux.DatosPersona.ContactoCliente.Direccion = (string)datos.Lector["direccion"];

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

        public int ModificarPaciente(Paciente seleccionado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_MODIFICAR_PACIENTE");
                datos.setearParametro("@ID_PACIENTE", seleccionado.DatosPersona.IdPersona);
                datos.setearParametro("@DNI", seleccionado.DatosPersona.Dni);
                datos.setearParametro("@NOMBRE", seleccionado.DatosPersona.Nombre);
                datos.setearParametro("@APELLIDO", seleccionado.DatosPersona.Apellido);
                datos.setearParametro("@FECHA_NACIMIENTO", seleccionado.DatosPersona.FechaNacimiento);
                datos.setearParametro("@EMAIL", seleccionado.DatosPersona.ContactoCliente.Email);
                datos.setearParametro("@TELEFONO", seleccionado.DatosPersona.ContactoCliente.telefono);
                datos.setearParametro("@DIRECCION", seleccionado.DatosPersona.ContactoCliente.Direccion);
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
