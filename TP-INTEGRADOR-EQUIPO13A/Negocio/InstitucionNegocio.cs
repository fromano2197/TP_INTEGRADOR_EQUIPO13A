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
                datos.setConsulta("select * from instituciones");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Institucion aux = new Institucion();
                    aux.IdInstitucion = int.Parse(datos.Lector["id_institucion"].ToString());
                    aux.Direccion = datos.Lector["direccion"].ToString();
                    aux.Fecha_Apertura = (DateTime)datos.Lector["fecha_apertura"];
                    aux.Nombre = datos.Lector["nombre"].ToString();
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

        public void Agregar(Institucion aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedimiento("SP_AGREGAR_INSTITUCION");


                datos.setearParametro("@NOMBRE_INSTITUCION", aux.Nombre);
                datos.setearParametro("@FECHA_APERTURA", aux.Fecha_Apertura);
                datos.setearParametro("@DIRECCION", aux.Direccion);

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

        public void cambiarEstado(Institucion aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedimiento("SP_MODIFICAR_ESTADO_INSTITUCION");
                datos.setearParametro("@ID", aux.IdInstitucion);
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

        public Institucion listar_porID(int ID)
        {
            Institucion aux = new Institucion();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select * from instituciones WHERE id_institucion =" + ID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.IdInstitucion = int.Parse(datos.Lector["id_institucion"].ToString());
                    aux.Fecha_Apertura = DateTime.Parse(datos.Lector["fecha_apertura"].ToString());
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.Direccion = (string)datos.Lector["direccion"];
                    aux.Activo = bool.Parse(datos.Lector["activo"].ToString());

                 
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

        public void Modificar(Institucion aux)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setConsulta("UPDATE instituciones SET nombre = @nombre, fecha_apertura = @fecha, direccion = @direccion WHERE id_institucion = @id");

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
