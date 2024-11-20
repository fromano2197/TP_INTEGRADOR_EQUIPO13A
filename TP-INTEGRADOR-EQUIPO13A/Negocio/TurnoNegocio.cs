using Dominio;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
        public List<Turno> CargarTurnosFiltrados(string filtro, int idProfesional) {

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
                    else {
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
    }
}



//        public List<Turno> listarConSp()
//        {
//            List<Turno> lista = new List<Turno>();
//            AccesoDatos datos = new AccesoDatos();
//            try
//            {
//                datos.setearProcedimiento("storedListar");
//                datos.ejecutarLectura();
//                while (datos.Lector.Read())
//                {
//                    Turno aux = new Turno();
//                    aux.IdTurno = datos.Lector.GetInt32(0);
//                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
//                    aux.Paciente = new Paciente();
//                    aux.Paciente.DatosPersona.Nombre = datos.Lector["Nombre"].ToString();
//                    aux.Paciente.DatosPersona.Apellido = datos.Lector["Apellido"].ToString();
//                    aux.Paciente.DatosPersona.Dni = int.Parse(datos.Lector["DNI"].ToString());
//                    lista.Add(aux);
//                }


//                return lista;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }
//    }
//}
