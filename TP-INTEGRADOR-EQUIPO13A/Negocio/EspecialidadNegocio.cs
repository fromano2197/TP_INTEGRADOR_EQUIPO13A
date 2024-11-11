using Dominio;
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
                datos.setConsulta("select * from especialidades WHERE activo = 1");
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

        public List<Especialidad> listar_porID(int ID)
        {
            List<Especialidad> lista = new List<Especialidad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select * from especialidades WHERE  id_especialidad =" + ID);
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

        public void eliminar(int ID)
        {
            AccesoDatos datos = new AccesoDatos();

            try
                {
                    
                    datos.setConsulta("UPDATE especialidades SET ACTIVO = 0 where id_especialidad=@id");
                    datos.setearParametro("@id", ID);
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