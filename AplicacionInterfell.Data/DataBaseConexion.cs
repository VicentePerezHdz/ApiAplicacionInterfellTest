using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace AplicacionInterfell.Data
{
    public class DataBaseConexion
    {

        #region Declaracion de Variables

        private string pstrDescripcionError;

        private SqlConnection pobjConexion;
        private SqlCommand pobjComando;
        public int ParametroDocumento;
        private string lsrtAseguradora;
        private string lsrtRECA;
        private string lstrRespuestaError;
        private int lintRespuestaErrorNumero;
        private string lstrClase;
        private string lstrAccion;
        private string lstrMetodo;

        #endregion

        #region Metodos de comportamiento, declarados por el programador o analista

        private string CrearMensajeError(string astrMetodo, string astrMensaje)
        {
            return "Clase: " + this.GetType().Name + "" + "Metodo: " + astrMetodo + "" + "Error: " + astrMensaje;
        }

        #region Manejo de conexiones

        public void IniciarConexion(string astrCadenaConexion)
        {
            this.pstrDescripcionError = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(astrCadenaConexion))
                {
                    throw new Exception("No se tiene una cadena de conexion");
                }
                if (this.pobjConexion == null || this.pobjConexion.State != ConnectionState.Open)
                {
                    this.pobjConexion = new SqlConnection(astrCadenaConexion);
                    this.pobjConexion.Open();
                }
            }
            catch (Exception ex)
            {
                this.pstrDescripcionError = this.CrearMensajeError(MethodBase.GetCurrentMethod().Name, ex.Message);
                throw ex;
            }
        }

        public void TerminarConexion()
        {
            this.pstrDescripcionError = string.Empty;
            try
            {
                if (this.pobjComando != null)
                {
                    this.pobjComando.Dispose();
                }
                if (this.pobjConexion != null && this.pobjConexion.State != ConnectionState.Closed)
                {
                    this.pobjConexion.Dispose();
                    this.pobjConexion.Close();
                }
            }
            catch (Exception ex)
            {
                this.pstrDescripcionError = this.CrearMensajeError(MethodBase.GetCurrentMethod().Name, ex.Message);
                throw ex;
            }
        }
        public static DataSet EjecutaStore(string storeName, List<SqlParameter> parameters, string strConnection)
        {
            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmm = new SqlCommand();
            DataSet dts = new DataSet();
            SqlDataAdapter dta = null;
            cmm.CommandType = CommandType.StoredProcedure;
            cmm.CommandText = storeName;
            cmm.Connection = cnn;

            if (parameters.Count > 0)
            {
                foreach (var item in parameters)
                {
                    cmm.Parameters.Add(item);

                }
            }




            try
            {
                cnn.Open();
                dta = new SqlDataAdapter(cmm);
                dta.Fill(dts);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }

            return dts;
        }

        public static DataSet EjecutaQuery(string storeName, List<SqlParameter> parameters, string strConnection)
        {

            SqlConnection cnn = new SqlConnection(strConnection);
            SqlCommand cmm = new SqlCommand();
            DataSet dts = new DataSet();
            SqlDataAdapter dta = null;
            cmm.CommandType = CommandType.Text;
            cmm.CommandText = storeName;
            cmm.Connection = cnn;

            if (parameters.Count > 0)
            {
                foreach (var item in parameters)
                {
                    cmm.Parameters.Add(item);

                }
            }
            try
            {
                cnn.Open();
                dta = new SqlDataAdapter(cmm);
                dta.Fill(dts);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnn.Close();
            }

            return dts;
        }
        #endregion

        #endregion
        #region  no se usa

        //public DataTable ObtenerAlumno()
        //{
        //    this.pstrDescripcionError = string.Empty;
        //    try
        //    {
        //        DataTable adtaDatosBusqueda = new DataTable("Alumnos");
        //        using (this.pobjComando = new SqlCommand("SPExeObtenerAlumno", this.pobjConexion))
        //        {
        //            this.pobjComando.CommandType = CommandType.Text;
        //            using (SqlDataReader sqlDataReader = this.pobjComando.ExecuteReader())
        //            {
        //                if (sqlDataReader.HasRows)
        //                {
        //                    adtaDatosBusqueda.Load(sqlDataReader);
        //                }
        //            }
        //        }
        //        return adtaDatosBusqueda;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.pstrDescripcionError = this.CrearMensajeError(MethodBase.GetCurrentMethod().Name, ex.Message);
        //        throw ex;
        //    }
        //}
        //public DataTable ObtenerCurso()
        //{
        //    this.pstrDescripcionError = string.Empty;
        //    try
        //    {
        //        DataTable adtaeObtenerCurso = new DataTable("ObtenerCurso");
        //        using (this.pobjComando = new SqlCommand("SPExeObtenerCurso", this.pobjConexion))
        //        {
        //            this.pobjComando.CommandType = CommandType.Text;
        //            using (SqlDataReader sqlDataReader = this.pobjComando.ExecuteReader())
        //            {
        //                if (sqlDataReader.HasRows)
        //                {
        //                    adtaeObtenerCurso.Load(sqlDataReader);
        //                }
        //            }
        //        }
        //        return adtaeObtenerCurso;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.pstrDescripcionError = this.CrearMensajeError(MethodBase.GetCurrentMethod().Name, ex.Message);
        //        throw ex;
        //    }
        //}
        //public DataTable ObtenerGrupo()
        //{
        //    this.pstrDescripcionError = string.Empty;
        //    try
        //    {
        //        DataTable adtaDatosGrupo = new DataTable("Grupo");
        //        using (this.pobjComando = new SqlCommand("SPExeObtenerGrupo", this.pobjConexion))
        //        {
        //            this.pobjComando.CommandType = CommandType.Text;
        //            using (SqlDataReader sqlDataReader = this.pobjComando.ExecuteReader())
        //            {
        //                if (sqlDataReader.HasRows)
        //                {
        //                    adtaDatosGrupo.Load(sqlDataReader);
        //                }
        //            }
        //        }
        //        return adtaDatosGrupo;
        //    }
        //    catch (Exception ex)
        //    {
        //        this.pstrDescripcionError = this.CrearMensajeError(MethodBase.GetCurrentMethod().Name, ex.Message);
        //        throw ex;
        //    }
        //}
        //public DataTable ObtenerMiembrosDeGrupo()
        //{
        //    this.pstrDescripcionError = string.Empty;
        //    try
        //    {
        //        DataTable adtaDatosMiembrosDeGrupo = new DataTable("MiembrosDeGrupo");
        //        using (this.pobjComando = new SqlCommand("SPExeObtenerMiembrosDeGrupo", this.pobjConexion))
        //        {
        //            this.pobjComando.CommandType = CommandType.Text;
        //            using (SqlDataReader sqlDataReader = this.pobjComando.ExecuteReader())
        //            {
        //                if (sqlDataReader.HasRows)
        //                {
        //                    adtaDatosMiembrosDeGrupo.Load(sqlDataReader);
        //                }
        //            }
        //            return adtaDatosMiembrosDeGrupo;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.pstrDescripcionError = this.CrearMensajeError(MethodBase.GetCurrentMethod().Name, ex.Message);
        //        throw ex;
        //    }
        //}
        //public DataTable ObtenerRoll()
        //{
        //    this.pstrDescripcionError = string.Empty;
        //    try
        //    {
        //        DataTable adtaDatosRoll = new DataTable("ObtenerRoll");
        //        using (this.pobjComando = new SqlCommand("SPExeObtenerRoll", this.pobjConexion))
        //        {
        //            this.pobjComando.CommandType = CommandType.Text;
        //            using (SqlDataReader sqlDataReader = this.pobjComando.ExecuteReader())
        //            {
        //                if (sqlDataReader.HasRows)
        //                {
        //                    adtaDatosRoll.Load(sqlDataReader);
        //                }
        //            }
        //            return adtaDatosRoll;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.pstrDescripcionError = this.CrearMensajeError(MethodBase.GetCurrentMethod().Name, ex.Message);
        //        throw ex;
        //    }
        //}
        //public DataTable ObtenerEnroll()
        //{
        //    this.pstrDescripcionError = string.Empty;
        //    try
        //    {
        //        DataTable adtaDatosEnroll = new DataTable("Enroll");

        //        using (this.pobjComando = new SqlCommand("SPExeEnroll", this.pobjConexion))
        //        {
        //            this.pobjComando.CommandType = CommandType.Text;
        //            using (SqlDataReader sqlDataReader = this.pobjComando.ExecuteReader())
        //            {
        //                if (sqlDataReader.HasRows)
        //                {
        //                    adtaDatosEnroll.Load(sqlDataReader);
        //                }
        //            }
        //            return adtaDatosEnroll;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.pstrDescripcionError = this.CrearMensajeError(MethodBase.GetCurrentMethod().Name, ex.Message);
        //        throw ex;
        //    }
        //}

        #endregion
    }
}
