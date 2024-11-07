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
                datos.setConsulta("select * from ESPECIALIDAD WHERE ACTIVO = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.IdEspecialidad = int.Parse(datos.Lector["IDESPECIALIDAD"].ToString());
                    aux.NombreEspecialidad = (string)datos.Lector["ESPECIALIDAD"];
                    aux.Activo = bool.Parse(datos.Lector["ACTIVO"].ToString());
                    
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
                datos.setConsulta("select * from ESPECIALIDAD WHERE IDESPECIALIDAD =" + ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.IdEspecialidad = int.Parse(datos.Lector["IDESPECIALIDAD"].ToString());
                    aux.NombreEspecialidad = (string)datos.Lector["ESPECIALIDAD"];


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
               
                datos.setConsulta("UPDATE ESPECIALIDAD SET ESPECIALIDAD = @especialidad WHERE IdEspecialidad = @id");

            
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
                    
                    datos.setConsulta("UPDATE ESPECIALIDAD SET ACTIVO = 0 where IDESPECIALIDAD=@id");
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