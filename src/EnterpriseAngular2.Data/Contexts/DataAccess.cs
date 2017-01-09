//using IntegrityWeb;// TODO: change this
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace APIHelpers
{
    public class DataLayer
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["Angular2Enterprise"].ConnectionString ?? "";//TODO: change this.

        public DataSet ExecuteQuery(SqlCommand sqlCmd)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = con;
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                    adapter.Fill(ds);
                }
            }
            catch (Exception e)
            {
                LoggingHandler.LogVerboseEvent(e.Message, e);
                return null;
            }
            return ds;
        }

        public int ExecuteQueryScalar(SqlCommand sqlCmd)
        {
            int scalarReturn = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Connection = con;
                    con.Open();
                    scalarReturn = Convert.ToInt32(sqlCmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                LoggingHandler.LogVerboseEvent(e.Message, e);
                return 0;
            }
            return scalarReturn;
        }
    }
}

