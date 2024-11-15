using Dominio;
using Negocio;
using System;
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
    


public List<Turno> listarPorProfesional(int id)
{
    List<Turno> lista = new List<Turno>();
    AccesoDatos datos = new AccesoDatos();

    try
    {
        datos.setConsulta(@"select t.id_turno, e.nombre as 'nombreespecialidad',t.fecha,t.hora,p.id_paciente ,p.nombre,p.apellido,p.dni,t.observaciones
                                    from turnos t
                                    inner join pacientes p on t.id_paciente=p.id_paciente
                                    inner join profesionales pr on t.id_profesional=pr.id_profesional
                                    inner join profesionales_especialidades pe on pe.id_profesional=pr.id_profesional
                                    inner join especialidades e on e.id_especialidad=pe.id_especialidad
									where pr.id_profesional = @id;");

        datos.setearParametro("@id", id);

        datos.ejecutarLectura();

        while (datos.Lector.Read())
        {
            Turno aux = new Turno();
            aux.IdTurno = datos.Lector.GetInt32(0);
            aux.Fecha = (DateTime)datos.Lector["fecha"];
            aux.Paciente = new Paciente();
            aux.Paciente.IdPaciente = (int)datos.Lector["id_paciente"];
            aux.Paciente.DatosPersona = new Persona();
            aux.Especialidad = new Especialidad();
            aux.Especialidad.NombreEspecialidad = datos.Lector["nombreespecialidad"].ToString();
            aux.Paciente.DatosPersona.Nombre = datos.Lector["nombre"].ToString();
            aux.Paciente.DatosPersona.Apellido = datos.Lector["apellido"].ToString();
            aux.Paciente.DatosPersona.Dni = datos.Lector["dni"].ToString();
            aux.Observaciones = datos.Lector["observaciones"].ToString();
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
