using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class InstitucionNegocio
    {
        public List<Institucion> listar()
        {
            List<Institucion> lista = new List<Institucion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select * from INSTITUCION WHERE ACTIVO = 1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Institucion aux = new Institucion();
                    aux.IdInstitucion = int.Parse(datos.Lector["IDINSTITUCION"].ToString());
                    aux.Direccion = datos.Lector["DIRECCION"].ToString();
                    aux.Fecha_Apertura = (DateTime)datos.Lector["FECHA_APERTURA"];
                    aux.Nombre = datos.Lector["NOMBRE_INSTITUCION"].ToString();
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

        public void Agregar(Institucion aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setConsulta("INSERT INTO INSTITUCION (NOMBRE_INSTITUCION, FECHA_APERTURA, DIRECCION) VALUES (@institucion, @fecha, @direccion)");
                datos.setearParametro("@institucion", aux.Nombre);
                datos.setearParametro("@fecha", aux.Fecha_Apertura);
                datos.setearParametro("@direccion", aux.Direccion);
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

                datos.setConsulta("UPDATE INSTITUCION SET ACTIVO = 0 where IDINSTITUCION=@id");
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

        public List<Institucion> listar_porID(int ID)
        {
            List<Institucion> lista = new List<Institucion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select * from INSTITUCION WHERE IDINSTITUCION =" + ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Institucion aux = new Institucion();
                    aux.IdInstitucion = int.Parse(datos.Lector["IDINSTITUCION"].ToString());
                    aux.Fecha_Apertura = DateTime.Parse(datos.Lector["FECHA_APERTURA"].ToString());
                    aux.Nombre = (string)datos.Lector["NOMBRE_INSTITUCION"];
                    aux.Direccion = (string)datos.Lector["DIRECCION"];
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

        public void Modificar(Institucion aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setConsulta("UPDATE INSTITUCION SET NOMBRE_INSTITUCION = @nombre, FECHA_APERTURA = @fecha, DIRECCION = @direccion WHERE IDINSTITUCION = @id");

                datos.setearParametro("@id", aux.IdInstitucion);
                datos.setearParametro("@nombre", aux.Nombre);
                datos.setearParametro("@fecha", aux.Fecha_Apertura);
                datos.setearParametro("@direccion", aux.Direccion);
               


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
