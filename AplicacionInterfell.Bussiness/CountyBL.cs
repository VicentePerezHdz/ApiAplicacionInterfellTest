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
        public string CadenaConexion = string.Empty;
        public CountyBL()
        {
            DataBaseConexion dataBaseConexion = new DataBaseConexion();

            //TODO: Falta la cadena de conexion
            // dataBaseConexion.IniciarConexion("");

        }

        public List<County> Obtener()
        {
            List<County> lstCounties = new List<County>();
            try
            {
                List<SqlParameter> Parametros = new List<SqlParameter>();
                DataSet dt = DataBaseConexion.EjecutaStore("SPSelectCounty", Parametros, CadenaConexion);


                if (!dt.HasErrors)
                {
                    if (dt.Tables.Count > 0)
                    {
                        foreach (DataRow row in dt.Tables[0].Rows)
                        {
                            lstCounties.Add(

                              new County
                              {

                                  county_fips = Convert.ToInt32(row["county_fips"].ToString()),
                                  county_name = row["county_name"].ToString(),
                                  state_name = row["state_name"].ToString(),
                                  date = DateTime.Parse(row["dateFech"].ToString()),
                                  county_vmt = Convert.ToInt32(row["county_vmt"].ToString()),
                                  baseline_jan_vmt = Convert.ToInt32(row["baseline_jan_vmt"].ToString()),
                                  percent_change_from_jan = float.Parse(row["percent_change_from_jan"].ToString()),
                                  mean7_county_vmt = float.Parse(row["mean7_county_vmt"].ToString()),
                                  mean7_percent_change_from_jan = float.Parse(row["mean7_percent_change_from_jan"].ToString()),
                                  date_at_low = DateTime.Parse(row["date_at_low"].ToString()),
                                  mean7_county_vmt_at_low = float.Parse(row["mean7_county_vmt_at_low"].ToString()),
                                  percent_change_from_low = float.Parse(row["percent_change_from_low"].ToString()),
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



            return lstCounties;
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

        public int Eliminar(int ID)
        {
            int resultado = 0;
            try
            {
                List<SqlParameter> Parametros = new List<SqlParameter>();

                DataSet dt = DataBaseConexion.EjecutaQuery("DELETE from County where county_fips=" + ID, Parametros, CadenaConexion);
                List<County> lstCounties = new List<County>();



                if (!dt.HasErrors)
                {
                    if (dt.Tables.Count > 0)
                    {
                        foreach (DataRow row in dt.Tables[0].Rows)
                        {
                            resultado = Convert.ToInt32(row["Resultado"].ToString());
                        }
                    }
                }
                return resultado;

            }
            catch (Exception e)
            {
                return 0;
            }

            //return null;
        }

        public int Insertar(County county)
        {
            int resultado = 0;
            //Resultado
            try
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
                DataSet dt = DataBaseConexion.EjecutaStore("SpInsertCounty", Parametros, CadenaConexion);


                if (!dt.HasErrors)
                {
                    if (dt.Tables.Count > 0)
                    {
                        foreach (DataRow row in dt.Tables[0].Rows)
                        {
                            resultado = Convert.ToInt32(row["Resultado"].ToString());
                        }
                    }
                }
                return resultado;
            }
            catch (Exception e)
            {

                return 0;
            }
        }
    }
}
