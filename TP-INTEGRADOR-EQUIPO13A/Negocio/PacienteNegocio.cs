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
                datos.setConsulta("select P.IDPERSONA, P.APELLIDO, P.NOMBRE, P.DNI from PERSONA as P \r\ninner join PACIENTE as PA on PA.IDPERSONA = P.IDPERSONA WHERE P.ACTIVO = 1 ORDER BY P.APELLIDO ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.IdPersona = datos.Lector.GetInt32(0);
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Dni = datos.Lector.GetInt32(3);
                    


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
        public int buscarIDPaciente(int DNI)
        {
            Paciente aux = new Paciente();
            AccesoDatos datos = new AccesoDatos();
            int IDPACIENTE = 0;
            try
            {
                datos.setConsulta("SELECT PC.IDPACIENTE FROM PACIENTE PC INNER JOIN PERSONA P ON PC.IDPERSONA = P.IDPERSONA WHERE P.DNI = @DNI;");
                datos.setearParametro("@DNI", DNI);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    aux.IdPaciente = int.Parse(datos.Lector["IDPACIENTE"].ToString());
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
                datos.setearParametro("@PASS", usuario.Password);
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
                datos.setConsulta(@"Select P.NOMBRE, P.APELLIDO, P.FECHA_NACIMIENTO, P.DNI, C.TELEFONO, C.EMAIL, C.DIRECCION from PERSONA AS P 
                                    INNER JOIN CONTACTO AS C ON C.IDPERSONA = P.IDPERSONA
                                    WHERE P.IDPERSONA = @IDPERSONA;");

                datos.setearParametro("@IDPERSONA", ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.DatosPersona.Dni = (int)datos.Lector["DNI"];
                    aux.DatosPersona.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.DatosPersona.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.DatosPersona.FechaNacimiento = (DateTime)datos.Lector["FECHA_NACIMIENTO"];
                    aux.DatosPersona.ContactoCliente.Email = (string)datos.Lector["EMAIL"];
                    aux.DatosPersona.ContactoCliente.telefono = (string)datos.Lector["TELEFONO"];
                    aux.DatosPersona.ContactoCliente.Direccion = (string)datos.Lector["DIRECCION"];

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
                datos.setearParametro("@IDPERSONA", seleccionado.DatosPersona.IdPersona);
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
