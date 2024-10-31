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
                datos.setConsulta("select * from INSTITUCION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Institucion aux = new Institucion();
                    aux.IdInstitucion = int.Parse(datos.Lector["IDINSTITUCION"].ToString());
                    aux.Direccion = datos.Lector["DIRECCION"].ToString();
                    aux.Fecha_Apertura = (DateTime)datos.Lector["FECHA_APERTURA"];
                    aux.Nombre = datos.Lector["NOMBRE_INSTITUCION"].ToString();



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
