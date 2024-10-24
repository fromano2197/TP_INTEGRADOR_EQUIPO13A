using Dominio;
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
                datos.setConsulta(" SELECT T.IDTURNO, T.FECHA, T.HORARIO, P.NOMBRE as NOMBRE, P.APELLIDO as APELLIDO, PR.IDUSUARIO as IDPROFESIONAL, E.ESPECIALIDAD as ESPECIALIDAD, T.OBSERVACIONES, PA.IDPERSONA FROM TURNO as T" +
                    "   JOIN PACIENTE as PA ON T.IDPACIENTE = PA.IDPERSONA" +
                    "   JOIN PERSONA as P ON PA.IDPERSONA = P.IDPERSONA" +
                    "   JOIN PROFESIONAL PR ON T.IDPROFESIONAL = PR.IDPROFESIONAL" +
                    "   JOIN ESPECIALIDAD E ON PR.IDESPECIALIDAD = E.IDESPECIALIDAD");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.IdTurno = datos.Lector.GetInt32(0);
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.IdPaciente = datos.Lector.GetInt32(0);
                    aux.Paciente.DatosPersona = new Persona();
                    aux.Paciente.DatosPersona.Nombre = datos.Lector["NOMBRE"].ToString();
                    aux.Paciente.DatosPersona.Apellido = datos.Lector["Apellido"].ToString();
                    aux.Paciente.DatosPersona.Dni = datos.Lector.GetInt32(0);
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
