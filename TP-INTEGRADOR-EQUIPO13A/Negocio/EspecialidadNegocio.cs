using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class EspecialidadNegocio
    {
        public List<Especialidad> listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select id_especialidad, nombre, activo from especialidades");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.IdEspecialidad = int.Parse(datos.Lector["id_especialidad"].ToString());
                    aux.NombreEspecialidad = (string)datos.Lector["nombre"];
                    aux.Activo = bool.Parse(datos.Lector["activo"].ToString());
                    
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

        public Especialidad listar_porID(int ID)
        {
            Especialidad aux = new Especialidad();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select * from especialidades WHERE  id_especialidad =" + ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.IdEspecialidad = int.Parse(datos.Lector["id_especialidad"].ToString());
                    aux.NombreEspecialidad = (string)datos.Lector["nombre"];
                    aux.Activo = (bool)datos.Lector["activo"];
                    
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

        public void Agregar(Especialidad aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedimiento("SP_AGREGAR_ESPECIALIDAD");


                datos.setearParametro("@ESPECIALIDAD", aux.NombreEspecialidad);

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

        public void Modificar(Especialidad aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
               
                datos.setConsulta("UPDATE especialidades SET nombre = @especialidad WHERE id_especialidad = @id");

            
                datos.setearParametro("@especialidad", aux.NombreEspecialidad);
                datos.setearParametro("@id", aux.IdEspecialidad);

               
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

        public void cambiarEstado(Especialidad aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
                {
                    
                    datos.setearProcedimiento("SP_MODIFICAR_ESTADO_ESPECIALIDAD");
                    datos.setearParametro("@ID", aux.IdEspecialidad);
                    datos.setearParametro("@ACTIVO", aux.Activo);
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

        public List<Especialidad> ObtenerEspecialidadesPorProfesional(int idProfesional)
        {
            List<Especialidad> lista = new List<Especialidad>();
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("SELECT e.id_especialidad, e.nombre FROM profesionales_especialidades pe " +
                                  "INNER JOIN especialidades e ON pe.id_especialidad = e.id_especialidad " +
                                  "WHERE pe.id_profesional = @idProfesional AND pe.activo = 1");
                datos.setearParametro("@idProfesional", idProfesional);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Especialidad especialidad = new Especialidad
                    {
                        IdEspecialidad = (int)datos.Lector["id_especialidad"],
                        NombreEspecialidad = (string)datos.Lector["nombre"]
                    };
                    lista.Add(especialidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }


        public List<Especialidad> listarPorProfesional(int ID)
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select e.nombre, pe.id_especialidad, pe.id_profesional from profesionales_especialidades pe " +
                                "inner join especialidades as e on pe.id_especialidad = e.id_especialidad " +
                                 "where pe.id_profesional = @idProfesional AND pe.activo = 1");

                datos.setearParametro("idProfesional", ID);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.IdEspecialidad = int.Parse(datos.Lector["id_especialidad"].ToString());
                    aux.NombreEspecialidad = (string)datos.Lector["nombre"];


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

        public int buscarIDEespecialidad(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setConsulta("SELECT id_especialidad FROM especialidades WHERE nombre COLLATE SQL_Latin1_General_CP1_CI_AI = @NombreEspecialidad COLLATE SQL_Latin1_General_CP1_CI_AI;");
                datos.setearParametro("@NombreEspecialidad", nombre);


                datos.ejecutarLectura();


                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["id_especialidad"];
                }
                else
                {
                    return -1;
                };

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

        public void AgregarEspecialidadProfesional(int IdProfesional, int IdEspecialidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedimiento("SP_AGREGAR_ESPECIALIDAD_PROFESIONAL");


                datos.setearParametro("@IDESPECIALIDAD", IdEspecialidad);
                datos.setearParametro("@IDPROFESIONAL", IdProfesional);
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
        public void EliminarRelacionProfesional(Especialidad aux, int IdProfesional)
        {
    AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedimiento("SP_MODIFICAR_ESTADO_PROFESIONAL_ESPECIALIDAD");
                datos.setearParametro("@IDESPECIALIDAD", aux.IdEspecialidad);
                datos.setearParametro("@IDPROFESIONAL", IdProfesional);
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