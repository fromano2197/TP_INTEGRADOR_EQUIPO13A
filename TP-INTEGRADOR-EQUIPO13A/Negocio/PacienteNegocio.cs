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
using System.Net.Mail;
using System.Net;

namespace Negocio
{
    public class PacienteNegocio
    {

        public List<Paciente> listar()
        {
            List<Paciente> lista = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select id_paciente,apellido,nombre,dni, activo from pacientes order by apellido asc;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.IdPaciente = datos.Lector.GetInt32(0);
                    aux.DatosPersona.Apellido = (string)datos.Lector["apellido"];
                    aux.DatosPersona.Nombre = (string)datos.Lector["nombre"];
                    aux.DatosPersona.Dni = (string)datos.Lector["dni"];
                    aux.activo = (bool)datos.Lector["activo"];



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

        public List<Paciente> listarPorProfesional(int id)
        {
            List<Paciente> lista = new List<Paciente>();
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
                    Paciente aux = new Paciente();
                    aux.IdPaciente = datos.Lector.GetInt32(0);
                    aux.DatosPersona.Apellido = (string)datos.Lector["apellido"];
                    aux.DatosPersona.Nombre = (string)datos.Lector["nombre"];
                    aux.DatosPersona.Dni = (string)datos.Lector["dni"];



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

        public void modificarEstado(Paciente paciente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("SP_MODIFICAR_ESTADO_PACIENTE");
                datos.setearParametro("@ID_PACIENTE", paciente.IdPaciente);
                datos.setearParametro("@ACTIVO", paciente.activo);
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
                        aux.Dni = (string)datos.Lector["dni"];
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

        public string RecuperarContraseña(int DNI)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT id_paciente FROM pacientes WHERE dni = @DNI;");
                datos.setearParametro("@DNI", DNI);
                datos.ejecutarLectura();

                int idPaciente = 0;
                if (datos.Lector.Read())
                {
                    idPaciente = int.Parse(datos.Lector["id_paciente"].ToString());
                }
                datos.cerrarConexion();

                if (idPaciente == 0)
                {
                    return "El DNI ingresado no está registrado.";
                }

                datos = new AccesoDatos();
                datos.setConsulta("SELECT contraseña FROM usuarios WHERE id_paciente = @IDPACIENTE;");
                datos.setearParametro("@IDPACIENTE", idPaciente);
                datos.ejecutarLectura();

                string password = string.Empty;
                if (datos.Lector.Read())
                {
                    password = datos.Lector["contraseña"].ToString();
                }
                datos.cerrarConexion();

                if (string.IsNullOrEmpty(password))
                {
                    return "No se encontró una contraseña asociada al DNI ingresado.";
                }

                string email = ObtenerEmailPorIdPaciente(idPaciente);
                if (string.IsNullOrEmpty(email))
                {
                    return "No se encontró un correo electrónico asociado al DNI ingresado.";
                }


                EnviarCorreoRecuperacion(email, password);
                return "Correo enviado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Ocurrió un error al procesar la solicitud: {ex.Message}";
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private string ObtenerEmailPorIdPaciente(int idPaciente)
        {
            string email = string.Empty;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT email FROM pacientes WHERE id_paciente = @IDPACIENTE;");
                datos.setearParametro("@IDPACIENTE", idPaciente);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    email = datos.Lector["email"].ToString();
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
            return email;
        }

        public void EnviarCorreoRecuperacion(string email, string contraseña)
        {
            try
            {
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("hernan39742374@gmail.com");
                mensaje.To.Add(email);
                mensaje.Subject = "Recuperación de Contraseña";

                mensaje.Body = $@"
        <html>
            <body style=""font-family: Arial, sans-serif; color: #333; text-align: center;"">
                <h1 style=""color: #0056b3;"">Recuperación de Contraseña</h1>
                <p>Has solicitado recuperar tu contraseña. Aquí está la información:</p>
                <p><strong>Contraseña:</strong> {contraseña}</p>
                <p style=""margin-top: 20px;"">
                    <img src=""https://i.pinimg.com/236x/76/91/f8/7691f809425069fa599eb6137f4d6071.jpg"" 
                        alt=""Logotipo"" style=""width: 300px; height: auto; display: block; margin: 0 auto;"" />
                </p>
                <p>Si tienes alguna duda, no dudes en <a href=""mailto:hernan39742374@gmail.com"" style=""color: #0056b3;"">contactarnos</a>.</p>
                <p>Gracias por confiar en nuestra clínica.</p>
            </body>
        </html>";

                mensaje.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new NetworkCredential("hernan39742374@gmail.com", "lbwwgljjoqxnbxqo"),
                    EnableSsl = true
                };

                smtp.Send(mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al enviar el correo: " + ex.Message);
            }
        }


        public int nuevoPaciente(Paciente nuevo, Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_AGREGAR_PACIENTE");
                datos.setearParametro("@DNI", nuevo.DatosPersona.Dni);
                datos.setearParametro("@NOMBRE", nuevo.DatosPersona.Nombre);
                datos.setearParametro("@APELLIDO", nuevo.DatosPersona.Apellido);
                datos.setearParametro("@FECHA_NACIMIENTO", nuevo.DatosPersona.FechaNacimiento);
                datos.setearParametro("@EMAIL", nuevo.DatosPersona.ContactoCliente.Email);
                datos.setearParametro("@TELEFONO", nuevo.DatosPersona.ContactoCliente.telefono);
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
                datos.setConsulta(@"select p.id_paciente, p.activo, p.nombre,apellido,p.fecha_nacimiento,p.dni,p.telefono,p.email,p.direccion, u.usuario, u.contraseña, u.id_paciente from pacientes as p
                                    inner join usuarios as u on p.id_paciente = u.id_paciente
                                    where p.id_paciente=@IDPACIENTE AND u.tipo_usuario = 'paciente';");

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
                    aux.activo = (bool)datos.Lector["activo"];
                    aux.IdPaciente = (int)datos.Lector["id_paciente"];
                    aux.Usuario = new Usuario();
                    aux.Usuario.User = datos.Lector["usuario"].ToString();
                    aux.Usuario.Password = datos.Lector["contraseña"].ToString();

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
        public bool ExisteUsuario(string usuario, string dni)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string query = @"
            SELECT COUNT(*)
            FROM usuarios u
            LEFT JOIN pacientes p ON u.id_paciente = p.id_paciente
            WHERE u.usuario = @Usuario OR p.dni = @Dni;";

                datos.setConsulta(query);
                datos.setearParametro("@Usuario", usuario);
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


    }
}