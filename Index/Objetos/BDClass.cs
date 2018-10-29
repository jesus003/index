using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace UrbaniaIntranet.Objetos
{
    public class BDClass
    {

        public SqlConnection conectar;
        public SqlConnection conectarCheck;

        String tbl = String.Empty;
        String ipDisplay = String.Empty;
        private string connStrng;

        public BDClass()
        {
            ConexionOpen();
        }
        public string getConnStrng()
        {
            return connStrng;
        }

        #region Inicializa Conexion
        public void ConexionOpen()
        {
            try
            {

            }
            catch (Exception)
            {
                throw;
            }
            try
            {//Data source=172.168.1.67\\REPCASETAS;Initial Catalog=Telepeaje;User Id=sa;Password=Er3t4ihv; MultipleActiveResultSets=True
                string ConnString = "Data source=sql.softcame.net,2302;Initial Catalog=indexfundacion;User Id=sistemas;Password=softcame123; MultipleActiveResultSets=True";
                connStrng = ConnString;

                conectar = new SqlConnection(ConnString);
                conectarCheck = new SqlConnection(ConnString);
            }
            catch (SqlException ex)
            {
                EventLog.WriteEntry("BDClass", "CONEXION_OPEN" + ex.Message);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("BDClass", "CONEXION_OPEN" + ex.Message);
            }
        }
        #endregion

        #region Abre Conexion
        private bool AbreConexion()
        {
            try
            {
                if (conectar.State != System.Data.ConnectionState.Open)
                {
                    ConexionOpen();
                    conectar.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                //string metodo = "AbreConexion";
                this.CerrarConexion();
                conectar.Close();
                EventLog.WriteEntry("BDClass", "ABRIR_CONEXION" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("BDClass", "ABRIR_CONEXION" + ex.Message);
                return false;
            }
        }

        private bool AbreConexionCheck()
        {
            try
            {
                if (conectarCheck.State != System.Data.ConnectionState.Open)
                {
                    conectarCheck.Open();
                }
                return true;
            }
            catch (SqlException ex)
            {
                //string metodo = "AbreConexion";
                this.CerrarConexion();
                conectarCheck.Close();
                EventLog.WriteEntry("BDClass", "ABRE_CONEXION_CHECK" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("BDClass", "ABRE_CONEXION_CHECK" + ex.Message);
                return false;
            }
        }
        #endregion

        #region Cierra Conexion
        private bool CerrarConexion()
        {
            try
            {
                if (conectar.State != System.Data.ConnectionState.Closed)
                {
                    conectar.Close();
                    conectar.Dispose();
                }
                return true;
            }
            catch (SqlException ex)
            {
                //string metodo = "CerrarConexion";
                string linea = ex.StackTrace.Substring(ex.StackTrace.Length - 8, 8);

                EventLog.WriteEntry("BDClass", "CERRAR_CONEXION" + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("BDClass", "CERRAR_CONEXION" + ex.Message);
                return false;
            }
        }
        #endregion


        #region captura
        public DataTable cmbx_Materiales()
        {
            if (this.AbreConexion())
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_CMBX_MATERIALES", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;

                    read = cmd.ExecuteReader();
                    table.Load(read);
                    read.Close();
                    CerrarConexion();
                    return table;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_MATERIALES" + ex.Message);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_MATERIALES" + ex.Message);
                }
            }
            return null;
        }
        public DataTable cmbx_Plantas()
        {
            if (this.AbreConexion())
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_CMBX_PLANTAS", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;

                    read = cmd.ExecuteReader();
                    table.Load(read);
                    read.Close();
                    CerrarConexion();
                    return table;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_PLANTAS" + ex.Message);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_PLANTAS" + ex.Message);
                }
            }
            return null;
        }

        public DataTable cmbx_Recicladores()
        {
            if (this.AbreConexion())
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_CMBX_RECICLADORES", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;

                    read = cmd.ExecuteReader();
                    table.Load(read);
                    read.Close();
                    CerrarConexion();
                    return table;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_RECICLADORES" + ex.Message);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_RECICLADORES" + ex.Message);
                }
            }
            return null;
        }

        public DataTable cmbx_Unidades()
        {
            if (this.AbreConexion())
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_CMBX_UNIDADES", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;

                    read = cmd.ExecuteReader();
                    table.Load(read);
                    read.Close();
                    CerrarConexion();
                    return table;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_UNIDADES" + ex.Message);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_UNIDADES" + ex.Message);
                }
            }
            return null;
        }

        public Int64 getFolio()
        {
            Int64 folio = 0;
            if (this.AbreConexion())
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_GET_FOLIO", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;

                    read = cmd.ExecuteReader();

                    while (read.Read()) {
                        folio = read.GetInt64(0);
                    }
                    read.Close();
                    CerrarConexion();
                    return folio;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_GET_FOLIO" + ex.Message);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_GET_FOLIO" + ex.Message);
                }
            }
            return 0;
        }

        public decimal INS_DONACION(string idPlanta,string idRecicladora,string fecha, string subtotal, string iva, string total,string capturo)
        {
            decimal valid = 0;
            if (this.AbreConexion())
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_INS_DONACION", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idPlanta", idPlanta);
                    cmd.Parameters.AddWithValue("@idRecicladora", idRecicladora);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@subtotal", subtotal);
                    cmd.Parameters.AddWithValue("@iva", iva);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@capturo", capturo);
                    read = cmd.ExecuteReader();

                    while (read.Read()) {
                        valid = read.GetDecimal(0);
                    }


                    read.Close();
                    CerrarConexion();
                    return valid;
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message);
                    EventLog.WriteEntry("BDClass", "SP_CMBX_RECICLADORES" + ex.Message);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_CMBX_RECICLADORES" + ex.Message);
                }
            }
            return 0;
        }

        public DataTable getDetalles(string id)
        {
            if (this.AbreConexion())
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_GET_DETALLESDONACION", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);
                    read = cmd.ExecuteReader();
                    table.Load(read);
                    read.Close();
                    CerrarConexion();
                    return table;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_GET_DETALLESDONACION" + ex.Message);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_GET_DETALLESDONACION" + ex.Message);
                }
            }
            return null;
        }

        public decimal INS_DONACIONDETALLE(string folio, string idMaterial, string boleta_pesaje, string pase_salida, string peso_pase, string peso_compra, string precio_unitario,string @unidad_medida,string total)
        {
            decimal valid = 0;
            if (this.AbreConexion())
            {
                try
                {
                    DataTable table = new DataTable();
                    SqlCommand cmd = new SqlCommand("SP_INS_DONACIONESDETALLE", conectar);
                    SqlDataReader read;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                    cmd.Parameters.AddWithValue("@boleta_pesaje", boleta_pesaje);
                    cmd.Parameters.AddWithValue("@pase_salida", @pase_salida);
                    cmd.Parameters.AddWithValue("@peso_pase", peso_pase);
                    cmd.Parameters.AddWithValue("@peso_compra", peso_compra);
                    cmd.Parameters.AddWithValue("@precio_unitario", precio_unitario);
                    cmd.Parameters.AddWithValue("@unidad_medida", unidad_medida);
                    cmd.Parameters.AddWithValue("@total", total);
                    read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        valid = read.GetDecimal(0);
                    }


                    read.Close();
                    CerrarConexion();
                    return valid;
                }
                catch (SqlException ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_INS_DONACIONESDETALLE" + ex.Message);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("BDClass", "SP_INS_DONACIONESDETALLE" + ex.Message);
                }
            }
            return 0;
        }
        #endregion


    }
}