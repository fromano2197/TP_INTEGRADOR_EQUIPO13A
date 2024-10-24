﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProfesionalNegocio
    {
        public List<Persona> listar()
        {
            List<Persona> lista = new List<Persona>();
           AccesoDatos datos = new AccesoDatos();

            try
            {
               
                datos.setConsulta("select P.APELLIDO, P.NOMBRE, P.DNI from PERSONA as P inner join PROFESIONAL as PR on PR.IDPERSONA = P.IDPERSONA ORDER BY P.APELLIDO ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Persona aux = new Persona();
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Dni = datos.Lector.GetInt32(2);


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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("delete from PERSONA where id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void ActualizarProfesional(Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();
            {
                try
                {
                    string consultaProfesional = "UPDATE persona....";

                    datos.setConsulta(consultaProfesional);

                    datos.setearParametro("@Nombre", persona.Nombre);
                    datos.setearParametro("@Descripcion", persona.Apellido);
                    datos.setearParametro("@IdMarca", persona.Dni);


                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public Persona listar(int DNI)
        {
            Persona aux = null;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("select P.APELLIDO, P.NOMBRE, P.DNI from PERSONA as P inner join PACIENTE as PA on PA.IDPERSONA = P.IDPERSONA WHERE P.DNI = @DNI");
                datos.setearParametro("@DNI", DNI);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (aux == null)
                    {
                        aux = new Persona();
                        aux.Dni = (int)datos.Lector["DNI"];
                        aux.Apellido = (string)datos.Lector["APELLIDO"];
                        aux.Nombre = (string)datos.Lector["NOMBRE"];
                    }
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
    }
}
