using Dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class TurnoNegocio
    {
        public List<Turno> listar()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"select t.id_turno,t.fecha,t.hora, p.nombre,p.apellido,pr.id_profesional,e.nombre,t.observaciones,p.id_paciente,p.dni
                                    from turnos t
                                    inner join pacientes p on t.id_paciente=p.id_paciente
                                    inner join profesionales pr on t.id_profesional=pr.id_profesional
                                    inner join profesionales_especialidades pe on pe.id_profesional=pr.id_profesional
                                    inner join especialidades e on e.id_especialidad=pe.id_especialidad;");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.IdTurno = datos.Lector.GetInt32(0);
                    aux.Fecha = (DateTime)datos.Lector["fecha"];
                    aux.Hora = (TimeSpan)datos.Lector["hora"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.IdPaciente = (int)datos.Lector["id_paciente"];
                    aux.Paciente.DatosPersona = new Persona();
                    aux.Paciente.DatosPersona.Nombre = datos.Lector["nombre"].ToString();
                    aux.Paciente.DatosPersona.Apellido = datos.Lector["apellido"].ToString();
                    aux.Paciente.DatosPersona.Dni = datos.Lector["dni"].ToString();
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
        public List<Turno> CargarTurnosFiltrados(string filtro, int idProfesional)
        {

            List<Turno> lista = new List<Turno>();
            DateTime hoy = DateTime.Now;
            DateTime fechaInicio;
            DateTime fechaFin;
            switch (filtro)
            {
                case "dia":
                    fechaInicio = hoy.Date;
                    fechaFin = hoy.Date;
                    break;

                case "semana":
                    fechaInicio = hoy.AddDays(-(int)hoy.DayOfWeek + (int)DayOfWeek.Monday).Date;
                    fechaFin = fechaInicio.AddDays(6).Date;
                    Console.WriteLine($"Rango de la semana: {fechaInicio:yyyy-MM-dd} - {fechaFin:yyyy-MM-dd}");
                    break;


                case "mes":
                    fechaInicio = new DateTime(hoy.Year, hoy.Month, 1);
                    fechaFin = fechaInicio.AddMonths(1).AddDays(-1);
                    break;

                default:
                    throw new ArgumentException("Filtro no válido", nameof(filtro));
            }

            return ListarTurnos(fechaInicio, fechaFin, idProfesional);
        }

        private List<Turno> ListarTurnos(DateTime fechaInicio, DateTime fechaFin, int idProfesional)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Turno> lista = new List<Turno>();

            try
            {
                datos.setConsulta(@"SELECT t.id_turno, e.nombre as especialidad, t.id_paciente, p.nombre, p.apellido, p.dni, t.fecha, t.hora, t.id_profesional, t.estado, t.observaciones FROM turnos AS t 
                                    INNER JOIN pacientes p ON t.id_paciente = p.id_paciente
                                    INNER JOIN especialidades as e on t.id_especialidad = e.id_especialidad
                                    where t.estado = 'reservado' AND CAST(t.fecha AS DATE) BETWEEN @fechaInicio AND @fechaFin AND id_profesional = @idProfesional
                                    ORDER BY t.fecha, t.hora;
                                  ");

                datos.setearParametro("@fechaInicio", fechaInicio);
                datos.setearParametro("@fechaFin", fechaFin);
                datos.setearParametro("@idProfesional", idProfesional);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.IdTurno = datos.Lector.GetInt32(0);
                    aux.Fecha = (DateTime)datos.Lector["fecha"];
                    aux.Hora = (TimeSpan)datos.Lector["hora"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.NombreEspecialidad = datos.Lector["especialidad"].ToString();
                    aux.Paciente = new Paciente();
                    aux.Paciente.IdPaciente = (int)datos.Lector["id_paciente"];
                    aux.Paciente.DatosPersona = new Persona();
                    aux.Paciente.DatosPersona.Nombre = datos.Lector["nombre"].ToString();
                    aux.Paciente.DatosPersona.Apellido = datos.Lector["apellido"].ToString();
                    aux.Paciente.DatosPersona.Dni = datos.Lector["dni"].ToString();
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






        public Turno listar(int id)
        {
            Turno aux = new Turno();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"select t.id_turno,t.fecha,t.hora, p.nombre,p.apellido,pr.id_profesional,e.nombre,t.observaciones,p.id_paciente,p.dni
                                    from turnos t
                                    inner join pacientes p on t.id_paciente=p.id_paciente
                                    inner join profesionales pr on t.id_profesional=pr.id_profesional
                                    inner join profesionales_especialidades pe on pe.id_profesional=pr.id_profesional
                                    inner join especialidades e on e.id_especialidad=pe.id_especialidad
	                                where id_turno = @id;");

                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    aux.IdTurno = datos.Lector.GetInt32(0);
                    aux.Fecha = (DateTime)datos.Lector["fecha"];
                    aux.Hora = (TimeSpan)datos.Lector["hora"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.IdPaciente = (int)datos.Lector["id_paciente"];
                    aux.Paciente.DatosPersona = new Persona();
                    aux.Paciente.DatosPersona.Nombre = datos.Lector["nombre"].ToString();
                    aux.Paciente.DatosPersona.Apellido = datos.Lector["apellido"].ToString();
                    aux.Paciente.DatosPersona.Dni = datos.Lector["dni"].ToString();

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

        public void RegistrarObservacion(Turno aux)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("SP_CARGAR_OBSERVACION");
                datos.setearParametro("@ID", aux.IdTurno);
                datos.setearParametro("@OBSERVACIONES", aux.Observaciones);
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
        public List<Turno> listarPorProfesional(int id)
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"select t.id_turno,t.estado, e.nombre as 'nombreespecialidad',CAST(t.fecha AS DATE) AS Fecha,t.hora,p.id_paciente ,p.nombre,p.apellido,p.dni,t.observaciones
                                    from turnos t
                                    inner join pacientes p on t.id_paciente=p.id_paciente
                                    inner join profesionales pr on t.id_profesional=pr.id_profesional
                                    inner join profesionales_especialidades pe on pe.id_profesional=pr.id_profesional
                                    inner join especialidades e on e.id_especialidad=pe.id_especialidad
									where pr.id_profesional = @id and t.estado ='reservado';");

                datos.setearParametro("@id", id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.IdTurno = datos.Lector.GetInt32(0);
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Hora = (TimeSpan)datos.Lector["hora"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.IdPaciente = (int)datos.Lector["id_paciente"];
                    aux.Paciente.DatosPersona = new Persona();
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.NombreEspecialidad = datos.Lector["nombreespecialidad"].ToString();
                    aux.Paciente.DatosPersona.Nombre = datos.Lector["nombre"].ToString();
                    aux.Paciente.DatosPersona.Apellido = datos.Lector["apellido"].ToString();
                    aux.Paciente.DatosPersona.Dni = datos.Lector["dni"].ToString();
                    if (datos.Lector["observaciones"].ToString() == null)
                    {
                        aux.Observaciones = "";
                    }
                    else
                    {
                        aux.Observaciones = datos.Lector["observaciones"].ToString();
                    }

                    aux.Estado = datos.Lector["estado"].ToString();
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

        public List<Turno> listarTurnos()
        {
            List<Turno> lista = new List<Turno>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"
            SELECT 
                T.id_turno, T.id_paciente, T.id_profesional, T.id_especialidad, T.id_institucion, I.nombre AS NombreInstitucion, 
                T.Fecha, T.Hora, T.Estado, T.Observaciones,
                P.nombre AS NombrePaciente,
                P.apellido AS ApellidoPaciente,
                PR.nombre AS NombreProfesional,
                PR.apellido AS ApellidoProfesional,
                E.Nombre AS NombreEspecialidad
            FROM Turnos T
            INNER JOIN Pacientes P ON T.id_paciente = P.id_paciente
            INNER JOIN Profesionales PR ON T.id_profesional = PR.id_profesional
            INNER JOIN Especialidades E ON T.id_especialidad = E.id_especialidad
            INNER JOIN Instituciones I ON I.id_institucion = T.id_institucion");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();

                    aux.IdTurno = datos.Lector.GetInt32(0);
                    aux.id_paciente = datos.Lector.GetInt32(1);
                    aux.id_profesional = datos.Lector.GetInt32(2);
                    aux.id_especialidad = datos.Lector.GetInt32(3);
                    aux.IdInstitucion = datos.Lector.GetInt32(4);
                    aux.Institucion = datos.Lector["NombreInstitucion"].ToString();
                    aux.Fecha = datos.Lector.GetDateTime(6);
                    aux.Hora = datos.Lector.GetTimeSpan(7);
                    aux.Estado = datos.Lector["Estado"].ToString();
                    aux.Observaciones = datos.Lector["Observaciones"].ToString();

                    aux.Paciente = new Paciente
                    {
                        IdPaciente = aux.id_paciente,
                        DatosPersona = new Persona
                        {
                            Nombre = datos.Lector["NombrePaciente"].ToString(),
                            Apellido = datos.Lector["ApellidoPaciente"].ToString()
                        }
                    };

                    aux.Profesional = new Profesional
                    {
                        IdProfesional = aux.id_profesional,
                        Persona = new Persona
                        {
                            Nombre = datos.Lector["NombreProfesional"].ToString(),
                            Apellido = datos.Lector["ApellidoProfesional"].ToString()
                        }
                    };

                    aux.Especialidad = new Especialidad
                    {
                        NombreEspecialidad = datos.Lector["NombreEspecialidad"].ToString()
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


        public void CrearTurno(int idProfesional, int idEspecialidad, DateTime fecha, TimeSpan hora, int idInstitucion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta(@"
            INSERT INTO Turnos ( id_profesional, id_especialidad, id_institucion, Fecha, Hora, Estado)
            VALUES (@IdProfesional, @IdEspecialidad, @IdInstitucion, @Fecha, @Hora, 'disponible');");

                datos.setearParametro("@IdProfesional", idProfesional);
                datos.setearParametro("@IdEspecialidad", idEspecialidad);
                datos.setearParametro("@IdInstitucion", idInstitucion);
                datos.setearParametro("@Fecha", fecha);
                datos.setearParametro("@Hora", hora);

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


        public void EliminarTurno(int idTurno)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("DELETE FROM Turnos WHERE IdTurno = @IdTurno");
                datos.setearParametro("@IdTurno", idTurno);
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
    }
}



