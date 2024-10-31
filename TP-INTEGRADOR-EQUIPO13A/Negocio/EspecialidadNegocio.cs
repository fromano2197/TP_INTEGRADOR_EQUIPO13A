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
                datos.setConsulta("select * from ESPECIALIDAD");
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

                datos.setConsulta("INSERT INTO ESPECIALIDAD (ESPECIALIDAD) VALUES (@especialidad)");
                datos.setearParametro("@especialidad", aux.NombreEspecialidad);
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
                    
                    datos.setConsulta("delete from ESPECIALIDAD where id=@id");
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