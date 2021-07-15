using AplicacionInterfell.Data;
using AplicacionInterfell.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AplicacionInterfell.Bussiness
{
    public class CountyBL
    {

        //Constructor se Inicializa con un objeto de la capa de datos
        // esto con la finalidad de obtener la cadena de conexion
        public CountyBL()
        {
            DataBaseConexion dataBaseConexion = new DataBaseConexion();

            //TODO: Falta la cadena de conexion
            dataBaseConexion.IniciarConexion("");

        }

        public List<County> Obtener()
        {
            try
            {
                List<SqlParameter> Parametros = new List<SqlParameter>();
                DataSet dt = DataBaseConexion.EjecutaQuery("Select *from Algo", Parametros, "");
                List<County> lstCounties = new List<County>();

                if (!dt.HasErrors)
                {
                    if (dt.Tables.Count > 0)
                    {
                        foreach (DataRow row in dt.Tables[0].Rows)
                        {
                            lstCounties.Add(

                              new County
                              {
                                  //La logica que falta
                                  //
                              });

                        }

                    }

                }

            }
            catch (Exception e)
            {
            }



            return null;
        }

        public List<County> Actualizar(int? Id)
        {
            try
            {
                List<SqlParameter> Parametros = new List<SqlParameter>();
                DataSet dt = DataBaseConexion.EjecutaQuery("Select *from Algo", Parametros, "");
                List<County> lstCounties = new List<County>();

                if (!dt.HasErrors)
                {
                    if (dt.Tables.Count > 0)
                    {
                        foreach (DataRow row in dt.Tables[0].Rows)
                        {
                            lstCounties.Add(

                              new County
                              {
                                  //La logica que falta
                                  //
                              });

                        }

                    }

                }
                return null;
            }
            catch (Exception e)
            {
            }
            return null;
        }

        public List<County> Eliminar(County county)
        {
            try
            {
                List<SqlParameter> Parametros = new List<SqlParameter>();
                DataSet dt = DataBaseConexion.EjecutaQuery("Select *from Algo", Parametros, "");
                List<County> lstCounties = new List<County>();

                if (!dt.HasErrors)
                {
                    if (dt.Tables.Count > 0)
                    {
                        foreach (DataRow row in dt.Tables[0].Rows)
                        {
                            lstCounties.Add(

                              new County
                              {
                                  //La logica que falta
                                  //
                              });

                        }

                    }

                }
                return null;
            }
            catch (Exception e)
            {
            }
            return null;
            //return null;
        }

        public int Insertar(County county)
        {
            return 0;
        }
    }
}
