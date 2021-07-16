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
                DataSet dt = DataBaseConexion.EjecutaStore("Exec SPSelectCounty", Parametros, "");
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
                                  county_fips = 0,
                                  county_name = "",
                                  state_name = "",
                                  date = DateTime.Now,
                                  county_vmt = 0,
                                  baseline_jan_vmt = 0,
                                  percent_change_from_jan = 0,
                                  mean7_county_vmt = 0,
                                  mean7_percent_change_from_jan = 0,
                                  date_at_low = DateTime.Now,
                                  mean7_county_vmt_at_low = 0,
                                  percent_change_from_low = 0,


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
                DataSet dt = DataBaseConexion.EjecutaStore("EXEC SpUpdCounty", Parametros, "");
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

        public List<County> Eliminar(int ID)
        {
            try
            {
                List<SqlParameter> Parametros = new List<SqlParameter>();

                DataSet dt = DataBaseConexion.EjecutaQuery("DELETE *from County where county_fips=" + ID, Parametros, "");
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
            List<SqlParameter> Parametros = new List<SqlParameter>();
            Parametros.Add(new SqlParameter("@county_name", SqlDbType.VarChar) { Value = county.county_name });
            Parametros.Add(new SqlParameter("@state_name", SqlDbType.VarChar) { Value = county.state_name });
            Parametros.Add(new SqlParameter("@dateFech", SqlDbType.Date) { Value = county.date });
            Parametros.Add(new SqlParameter("@county_vmt", SqlDbType.VarChar) { Value = county.county_vmt });
            Parametros.Add(new SqlParameter("@baseline_jan_vmt", SqlDbType.Int) { Value = county.baseline_jan_vmt });
            Parametros.Add(new SqlParameter("@percent_change_from_jan", SqlDbType.Float) { Value = county.percent_change_from_jan });
            Parametros.Add(new SqlParameter("@mean7_county_vmt ", SqlDbType.Float) { Value = county.mean7_county_vmt });
            Parametros.Add(new SqlParameter("@mean7_percent_change_from_jan", SqlDbType.Float) { Value = county.mean7_percent_change_from_jan });
            Parametros.Add(new SqlParameter("@date_at_low", SqlDbType.Date) { Value = county.date_at_low });
            Parametros.Add(new SqlParameter("@mean7_county_vmt_at_low", SqlDbType.Float) { Value = county.mean7_county_vmt_at_low });
            Parametros.Add(new SqlParameter("@percent_change_from_low", SqlDbType.Float) { Value = county.percent_change_from_low });
            DataSet dt = DataBaseConexion.EjecutaStore("Exec SpInsertCounty", Parametros, "");
            return 0;
        }
    }
}
